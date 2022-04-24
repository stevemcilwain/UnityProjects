
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MountainSO", menuName = "ScriptableObjects/MountainSO")]
public class MountainSO : ScriptableObject
{

    public bool EnableDebug;

    [Header("Left Edge")]
    public Vector2 LeftTop;
    public Vector2 SlopeTop;
    public Vector2 LeftBottom;

    [Header("Right Edge")]
    public Vector2 RightTop;
    public Vector2 SlopeBottom;
    public Vector2 RightBottom;


    [Header("Slope Point Count")]

    public int MinPointCount;
    public int MaxPointCount;

    [Header("Slope Point Height")]

    public float MinPointHeight;
    public float MaxPointHeight;

    [Header("Hills and Cliffs")]
    public PointTangent[] Tangents;

    [Header("Prefabs")]
    public GameObject TreePrefab;

    [System.Serializable]
    public class PointTangent
    {
        public Vector3 Left;
        public Vector3 Right;
    }

    public int RandomPointCount()
    {
        var pointCount = Random.Range(MinPointCount, MaxPointCount + 1);
        if (EnableDebug) Debug.LogFormat("MountainSO: chose random point count {0}", pointCount);
        return pointCount;
    }

    public float RandomPointHeight()
    {
        var pointHeight = Random.Range(MinPointHeight, MaxPointHeight);
        if (EnableDebug) Debug.LogFormat("MountainSO: chose random point height {0}", pointHeight);
        return pointHeight;
    }

    public PointTangent RandomTangent()
    {
        var randomTangentIndex = UnityEngine.Random.Range(0, Tangents.Length);
        if (EnableDebug) Debug.LogFormat("MountainSO: chose random tangent index {0}", randomTangentIndex);
        return Tangents[randomTangentIndex];
    }

}

