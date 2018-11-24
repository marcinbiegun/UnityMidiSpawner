using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class MeshBuilder {

	static public MeshData BuildQuad(int index, Vector3 center) {
        var vertices = new List<Vector3> {
            new Vector3(0, 0, 0) + center,
            new Vector3(0, 0, 1) + center,
            new Vector3(1, 0, 0) + center,
            new Vector3(1, 0, 1) + center
        };
        var triangles = new List<int> {
            0 + index, 1 + index, 2 + index,
            2 + index, 1 + index, 3 + index
        };

        return new MeshData {
            Vertices = vertices,
            Triangles = triangles,
            EndIndex = index + vertices.Count
        };
    }
}
