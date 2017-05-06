﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorEdge2DEditor : EditorWindow
{

    [MenuItem("Window/EdgeCollider2D Snap")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(EditorEdge2DEditor));
    }

    EdgeCollider2D edge;
    Vector2[] vertices = new Vector2[0];

    void OnGUI()
    {
        GUILayout.Label("EdgeCollider2D point editor", EditorStyles.boldLabel);
        edge = (EdgeCollider2D)EditorGUILayout.ObjectField("EdgeCollider2D to edit", edge, typeof(EdgeCollider2D), true);
        if (vertices.Length != 0)
        {
            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices[i] = (Vector2)EditorGUILayout.Vector2Field("Element " + i, vertices[i]);
            }
        }

        if (GUILayout.Button("Retrieve"))
        {
            vertices = edge.points;
        }

        if (GUILayout.Button("Set"))
        {
            edge.points = vertices;
        }
    }

    /*
        void OnSelectionChange() {
            if (Selection.gameObjects.Length == 1) {
                EdgeCollider2D aux = Selection.gameObjects[0].GetComponent<EdgeCollider2D>();

                if (aux) {
                    edge = aux;
                    vertices = edge.points;
                }
            }
        }
    */
}