using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class MountainGenerator : MonoBehaviour
{
    // ---------- Inspector

    [Tooltip("Add one or more mountains.")]
    public MountainCollectionSO Mountains;

    [Tooltip("Add one or more trees.")]
    public TreeCollectionSO Trees;

    [Tooltip("Event to publish after generation.")]
    public MountainGeneratedEventSO MountainGenerated;

    // ---------- Private State

    private SpriteShapeController _shape;
    private Spline _spline;

    private const int LEFT_BOTTOM = 0;
    private const int LEFT_TOP = 1;
    private const int SLOPE_TOP = 2;
    private int SLOPE_BOTTOM = 3;
    private int RIGHT_TOP = 4;
    private int RIGHT_BOTTOM = 5;


    private float _slopeDistance;
    private int _slopePointCount;
    private List<Vector3> _points;

    // ---------- LifeCycle Events

    private void Awake()
    {
        // cache components
        _shape = GetComponent<SpriteShapeController>();
        _spline = _shape.spline;

        // initialization
        _points = new List<Vector3>();

    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    // ---------- Metohds

    private IEnumerator Generate()
    {
        var mountain = Mountains.RandomMountain();

        _spline.SetPosition(LEFT_TOP, mountain.LeftTop);
        _spline.SetPosition(LEFT_BOTTOM, mountain.LeftBottom);
        _spline.InsertPointAt(SLOPE_TOP, mountain.SlopeTop);
        _spline.SetTangentMode(SLOPE_TOP, ShapeTangentMode.Continuous);
        _spline.InsertPointAt(SLOPE_BOTTOM, mountain.SlopeBottom);
        _spline.SetTangentMode(SLOPE_BOTTOM, ShapeTangentMode.Continuous);
        _spline.SetPosition(RIGHT_TOP, mountain.RightTop);
        _spline.SetPosition(RIGHT_BOTTOM, mountain.RightBottom);

        _slopeDistance = Vector2.Distance(mountain.SlopeTop, mountain.SlopeBottom);

        _slopePointCount = mountain.RandomPointCount();

        for (int p = 1; p < _slopePointCount; p++)
        {
            try
            {
                // Offset point indexes starting with SLOPE_TOP
                var thisPointIndex = SLOPE_TOP + p;
                var slopePointIndex = p - 1;

                // Set the height of this point
                var height = mountain.RandomPointHeight();

                // Spread points evenly across the slope

                float progress = (float)p / _slopePointCount;
                Vector2 lerpedPoint = Vector2.Lerp(mountain.SlopeTop, mountain.SlopeBottom, progress);
                Vector3 point = new Vector3(lerpedPoint.x, lerpedPoint.y + height);

                _spline.InsertPointAt(thisPointIndex, point);

                // set this point's tangents
                MountainSO.PointTangent tangent = mountain.RandomTangent();
                _spline.SetTangentMode(thisPointIndex, ShapeTangentMode.Continuous);
                _spline.SetLeftTangent(thisPointIndex, tangent.Left);
                _spline.SetRightTangent(thisPointIndex, tangent.Right);


                // add to the slope points collection

                _points.Add(point);

                // Add a random tree using the slope points

                var tree = Trees.RandomTree();
                AddObjectToPoint(tree, slopePointIndex);

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }

        // reet the indexes for everything after the points being added
        SLOPE_BOTTOM += _slopePointCount;
        RIGHT_BOTTOM += _slopePointCount;
        RIGHT_TOP += _slopePointCount;


        _shape.BakeMesh();
        _shape.BakeCollider();

        MountainGenerated.Publish?.Invoke();

        yield return null;
    }

    private void AddObjectToPoint(GameObject prefab, int index)
    {
        var point = _points[index];
        var go = Instantiate(prefab, point, Quaternion.identity);

    }

    private float Angle(Vector3 a, Vector3 b)
    {
        float dot = Vector3.Dot(a, b);
        float det = (a.x * b.y) - (b.x * a.y);
        return Mathf.Atan2(det, dot) * Mathf.Rad2Deg;
    }

    private void OnDrawGizmos()
    {

#if UNITY_EDITOR

        for (int i = 0; i < Mountains.Mountains.Length; i++)
        {
            Gizmos.DrawLine(Mountains.Mountains[i].LeftBottom, Mountains.Mountains[i].LeftTop);
            Gizmos.DrawLine(Mountains.Mountains[i].LeftTop, Mountains.Mountains[i].SlopeTop);
            Gizmos.DrawLine(Mountains.Mountains[i].SlopeTop, Mountains.Mountains[i].SlopeBottom);
            Gizmos.DrawLine(Mountains.Mountains[i].SlopeBottom, Mountains.Mountains[i].RightTop);
            Gizmos.DrawLine(Mountains.Mountains[i].RightTop, Mountains.Mountains[i].RightBottom);
            Gizmos.DrawLine(Mountains.Mountains[i].RightBottom, Mountains.Mountains[i].LeftBottom);
        }

#endif

    }

}
