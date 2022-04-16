using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{

    [SerializeField] private float sizeX = 1f;
    [SerializeField] private float sizeY = 1f;
    [SerializeField] private float sizeZ = 1f;
    [SerializeField] private Material material;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private Mesh mesh;

    private void Awake()
    {

        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = material;

        meshFilter = gameObject.AddComponent<MeshFilter>();
        mesh = new Mesh();

        BuildMesh();
    }

    private void BuildMesh()
    {
        var vertices = BuildVertices();
        var triangles = BuildTriangles();
        var normals = BuildNormals();
        var uvs = BuildUVs();

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        mesh.Optimize();

        meshFilter.mesh = mesh;

    }

    private Vector3[] BuildVertices()
    {
        var LEFT = -sizeX * .5f;
        var RIGHT = sizeX * .5f;

        var BOTTOM = 0f;
        var TOP = sizeY;

        var FRONT = 0f;
        var BACK = sizeZ;

        var i = new Vector3[8]; // indices of corners

        /* Build the bottom plane vertices 

              3--------------------2
              |                    |
              0--------------------1

        */

        i[0] = new Vector3(LEFT, BOTTOM, BACK);
        i[1] = new Vector3(RIGHT, BOTTOM, BACK);
        i[2] = new Vector3(RIGHT, BOTTOM, FRONT);
        i[3] = new Vector3(LEFT, BOTTOM, FRONT);

        /* Build the top plane vertices 

              7--------------------6
              |                    |
              4--------------------5

        */

        i[4] = new Vector3(LEFT, TOP, BACK);
        i[5] = new Vector3(RIGHT, TOP, BACK);
        i[6] = new Vector3(RIGHT, TOP, FRONT);
        i[7] = new Vector3(LEFT, TOP, FRONT);

        Vector3[] vertices = new Vector3[]
        {
            i[0], i[1], i[2], i[3], // Bottom
	        i[7], i[4], i[0], i[3], // Left
	        i[4], i[5], i[1], i[0], // Front
	        i[6], i[7], i[3], i[2], // Back
	        i[5], i[6], i[2], i[1], // Right
	        i[7], i[6], i[5], i[4]  // Top
        };

        return vertices;

    }

    private int[] BuildTriangles()
    {
        return new int[]
        {
            3, 1, 0,        3, 2, 1,        // Bottom	
            7, 5, 4,        7, 6, 5,        // Left
            11, 9, 8,       11, 10, 9,      // Front
            15, 13, 12,     15, 14, 13,     // Back
            19, 17, 16,     19, 18, 17,	    // Right
            23, 21, 20,     23, 22, 21,     // Top
        };
    }

    private Vector3[] BuildNormals()
    {
        return new Vector3[]
        {
            Vector3.down, Vector3.down, Vector3.down, Vector3.down,             // Bottom
            Vector3.left, Vector3.left, Vector3.left, Vector3.left,             // Left
            Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward,	// Front
            Vector3.back, Vector3.back, Vector3.back, Vector3.back,             // Back
            Vector3.right, Vector3.right, Vector3.right, Vector3.right,         // Right
            Vector3.up, Vector3.up, Vector3.up, Vector3.up                      // Top
        };
    }

    private Vector2[] BuildUVs()
    {
        return new Vector2[]
        {
            Vector2.one, Vector2.up, Vector2.zero, Vector2.right, // Bottom
	        Vector2.one, Vector2.up, Vector2.zero, Vector2.right, // Left
	        Vector2.one, Vector2.up, Vector2.zero, Vector2.right, // Front
	        Vector2.one, Vector2.up, Vector2.zero, Vector2.right, // Back	        
	        Vector2.one, Vector2.up, Vector2.zero, Vector2.right, // Right 
	        Vector2.one, Vector2.up, Vector2.zero, Vector2.right  // Top
        };
    }


}
