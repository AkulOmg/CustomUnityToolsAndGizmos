using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//Adds the Cordinates above  the Game object
[CustomEditor(typeof(MyComponent))]
public class MyComponentEditor : Editor
{

    void OnSceneGUI()
    {
        /*MyComponent mc = (MyComponent)target;
        Vector3 position = mc.transform.position + Vector3.up * 0.6f;
        Handles.Label(position, "position: " + mc.transform.position.ToString());*/

        /*MyComponent mcArc = (MyComponent)target;
        Handles.DrawWireArc(mcArc.transform.position, mcArc.transform.up,
            -mcArc.transform.right, 180, mcArc.floatValue);

        MyComponent mcH = (MyComponent)target;
        Handles.DrawWireArc(mcH.transform.position, mcH.transform.up, -mcH.transform.right, 180,
            mcH.floatValue);

        mcH.floatValue = (float)Handles.ScaleValueHandle(mcH.floatValue, mcH.transform.position + mcH.transform.forward * mcH.floatValue, mcH.transform.rotation, 1, Handles.ConeHandleCap, 1);*/


    }
    


    //No clue what the code below  actualy does

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        {
            MyComponent mc = (MyComponent)target;
            mc.floatValue = EditorGUILayout.Slider("SomeLabel", mc.floatValue, 0f, 10f);
        }
    }



    



}
