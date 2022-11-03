using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



//Has the colour change and object position code together(final)


[ExecuteInEditMode]
public class ObjectPosition : EditorWindow
{
    static public GameObject source;//lets you pic game object


    private float scale;

    Color color;


    [MenuItem("Object Editor/GameObjectEditor %&o")]
    static void ShowWindow()
    {

        EditorWindow.GetWindow(typeof(ObjectPosition));


    }



    public void OnGUI()
    {

        

        EditorGUILayout.BeginHorizontal();
        source = EditorGUILayout.ObjectField("Prefab", source, typeof(GameObject), true) as GameObject;//Lets you select the game object that will  be edited!
        EditorGUILayout.EndHorizontal();


        //Change chosen objects oriantation

        if (GUILayout.Button("Turn GameObject Position +45"))
            source.transform.Rotate(Vector3.right * 45); ;

        if (GUILayout.Button("Turn GameObject Position -45"))
            source.transform.Rotate(Vector3.left * 45); ;


        if (GUILayout.Button("Turn GameObject Position up -45"))
            source.transform.Rotate(Vector3.up * 45); ;


        if (GUILayout.Button("Turn GameObject Position down +45"))
            source.transform.Rotate(Vector3.down * 45);

        //Applied a random rotation to the selected game object
        if (GUILayout.Button("Apply random Rotation"))
        {


            foreach (var selectedObject in Selection.gameObjects)
            {
                selectedObject.transform.rotation = Quaternion.Euler
                (
                    Random.Range(-360f, 360f),
                    Random.Range(-360f, 360f),
                    Random.Range(-360f, 360f)
                );
            }

        }


        //Scales the object up/down evenly

        scale = EditorGUILayout.FloatField("Scale", scale);

        if (GUILayout.Button("Scale"))
        {
            foreach (var selectedObject in Selection.gameObjects)
            {

                selectedObject.transform.localScale = Vector3.one * scale;

            }
        }

        //Lets the user chnage the colour of the game object and all other game objects that use the same shader

        GUILayout.Label("when selected will change the colour of all game objects with the same Shader", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Change Colour"))
        {
            Colorize();
        }

    }

    void Colorize()//Will chnage the colour of all the objects that use the same shader
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}