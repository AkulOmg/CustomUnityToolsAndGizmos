﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReplacePrefab : EditorWindow
{

    [MenuItem("Object Editor/ReplacePrefab %&r")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ReplacePrefab));
    }

    static public GameObject source;

    public void OnGUI()
    {
        if (GUILayout.Button("Replace the selected GameObjects with your prefab"))
        {
            ReplaceSelected();
        }

        EditorGUILayout.BeginHorizontal();
        source = EditorGUILayout.ObjectField("Prefab", source, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Rename delete (clone)"))
        {
            Rename();
        }
    }
    private static void ReplaceSelected()
    {
        GameObject[] go = Selection.gameObjects;
        int go_count = 0;
        foreach (GameObject g in go)
        {
            go_count++;
            Transform trans = g.transform;
            Transform parent = trans.parent;

            GameObject instance = Instantiate(source) as GameObject;
            instance.transform.parent = parent;
            instance.transform.localPosition = trans.localPosition;
            instance.transform.localRotation = trans.localRotation;
            instance.transform.localScale = trans.localScale;

            GameObject.DestroyImmediate(g);
            string name = instance.name;
            instance.name = name.Substring(0, name.Length - 7);
        }

        Debug.Log(string.Format("Replaced {0} GameObjects", go_count));
    }

    private static void Rename()
    {
        GameObject[] go = Selection.gameObjects;
        /*int go_count = 0, components_count = 0, missing_count = 0;*/
        foreach (GameObject g in go)
        {
            /*go_count++;*/
            string name = g.name;
            g.name = name.Substring(0, name.Length - 7);
        }

        Debug.Log(string.Format("Replaced {0} GameObjects"/*, go_count*/));
    }
}