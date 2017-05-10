using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BakeNavMeshes))]
public class NavMeshBakeEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        BakeNavMeshes script = (BakeNavMeshes)target;
        if(GUILayout.Button("Bake Navmesh")) script.BakeNavMesh();
    }
}
