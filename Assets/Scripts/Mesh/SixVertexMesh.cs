using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SixVertexMesh : MonoBehaviour {

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    void Awake() {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Update() {
        MakeMeshData();
        UpdateMesh();
    }

    void MakeMeshData() {
        vertices = new Vector3[] {
            new Vector3(0,YValue.ins.yValue,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),

            new Vector3(1,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,1)
        };

        triangles = new int[] {
          0, 1, 2,
            3, 4, 5
        };
    }

    void UpdateMesh() {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

}

