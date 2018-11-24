using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshSpawner : MonoBehaviour {

    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    void Awake() {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    void Start() {
        MakeMeshData();
        UpdateMesh();
    }

    void MakeMeshData() {
        Vector3 center = new Vector3(0, 0, 0);
        var index = 0;

        for (int i = 0; i < 10; i++) {
            Debug.Log(center);
            Debug.Log(index);
            MeshData quad = MeshBuilder.BuildQuad(index, center);
            vertices.AddRange(quad.Vertices);
            triangles.AddRange(quad.Triangles);

            index = quad.EndIndex;
            center += new Vector3(1, 0, 0);
        }
    }

    void UpdateMesh() {
        Debug.Log("Building mesh with " + vertices.Count.ToString() + " vertices.");
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

}

