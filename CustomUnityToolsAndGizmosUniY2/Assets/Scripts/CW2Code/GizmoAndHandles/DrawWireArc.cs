using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MyComponent))]

public class DrawWireArc : Editor
{
    private void OnSceneGUI()
    {

        //creates arc
        MyComponent mcArc = (MyComponent)target;
        Handles.DrawWireArc(mcArc.transform.position, mcArc.transform.up,
            -mcArc.transform.right, 180, mcArc.floatValue);

        MyComponent mc = (MyComponent)target;
        Vector3 position = mc.transform.position + Vector3.up * 0.6f;
        Handles.Label(position, "position: " + mc.transform.position.ToString());

        //creates handle to adjust arc

        MyComponent mcH = (MyComponent)target;
        Handles.DrawWireArc(mcH.transform.position, mcH.transform.up, -mcH.transform.right, 180,
            mcH.floatValue);

        mcH.floatValue = (float)Handles.ScaleValueHandle(mcH.floatValue, mcH.transform.position + mcH.transform.forward * mcH.floatValue, mcH.transform.rotation, 1, Handles.ConeHandleCap, 1);

    }
}
