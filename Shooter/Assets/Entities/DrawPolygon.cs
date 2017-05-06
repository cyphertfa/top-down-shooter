using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[ExecuteInEditMode]
public class DrawPolygon : MonoBehaviour {

    PolygonCollider2D polygonComponent;
    MeshFilter meshFilterComponent;

	// Use this for initialization
	void Start () {
        polygonComponent = GetComponent<PolygonCollider2D>();
        meshFilterComponent = GetComponent<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2[] points = polygonComponent.points;
        //Generate mesh
        meshFilterComponent.mesh = CreateMesh(points);
    }

    Mesh CreateMesh(Vector2[] points)
    {

        Mesh mesh = new Mesh();
        //Vertices
        var vertex = new Vector3[points.Length];
        int x;
        for (x = 0; x < points.Length; x++)
        {
            vertex[x] = new Vector3(points[x].x, points[x].y,0);
        }

        //UVs
        var uvs = new Vector2[vertex.Length];

        for (x = 0; x < vertex.Length; x++)
        {
            if ((x % 2) == 0)
            {
                uvs[x] = new Vector2(0, 0);
            }
            else
            {
                uvs[x] = new Vector2(1, 1);
            }
        }

        //Triangles
        int[] tris = new int[3 * (vertex.Length - 2)];    //3 verts per triangle * num triangles
        int C1;
        int C2;
        int C3;

        int num = 1;

        if (num == 0)
        {
            C1 = 0;
            C2 = 1;
            C3 = 2;

            for (x = 0; x < tris.Length; x += 3)
            {
                tris[x] = C1;
                tris[x + 1] = C2;
                tris[x + 2] = C3;

                C2++;
                C3++;
            }
        }
        else
        {
            C1 = 0;
            C2 = vertex.Length - 1;
            C3 = vertex.Length - 2;

            for (x = 0; x < tris.Length; x += 3)
            {
                tris[x] = C1;
                tris[x + 1] = C2;
                tris[x + 2] = C3;

                C2--;
                C3--;
            }
        }

        //Assign data to mesh
        mesh.vertices = vertex;
        mesh.uv = uvs;
        mesh.triangles = tris;

        //Recalculations
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        //Name the mesh
        mesh.name = "MyMesh";

        //Return the mesh
        return mesh;
    }
}
