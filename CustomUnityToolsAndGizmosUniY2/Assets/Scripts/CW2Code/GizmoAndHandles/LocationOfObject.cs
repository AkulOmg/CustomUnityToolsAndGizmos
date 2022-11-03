using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(MyPosition))]
public class LocationOfObject : Editor
{
    void OnSceneGUI()
    {

        
        MyPosition mc = (MyPosition)target;
        Vector3 position = mc.transform.position + Vector3.up * 0.6f;
        Handles.Label(position, "position: " + mc.transform.position.ToString());

        
    }



    

}
