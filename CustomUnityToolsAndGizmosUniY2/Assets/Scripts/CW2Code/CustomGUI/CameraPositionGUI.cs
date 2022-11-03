using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CameraPositionGUI : MonoBehaviour
{
    
    Vector3 point;


    private void Update()
    {
        // Find screen position for target
        /*point = Camera.main.WorldToScreenPoint(Object.position);*/
    }

    void OnGUI()
    {




        if (GUI.Button(new Rect(10, 10, 200, 20), "BackCameraPosition"))//where the button would be 
        {
            Debug.Log("You clicked me!");
            transform.position = new Vector3(25f, 55f, -120f);//what happens to the game object the script is attached too

        }


        if (GUI.Button(new Rect(10, 40, 200, 20), "StartCameraPosition"))
        {
            Debug.Log("You clicked me! 2");
            transform.position = new Vector3(-66, -10, -53);
        }


        if (GUI.Button(new Rect(10, 70, 200, 20), "LeftCameraPosition"))
        {
            Debug.Log("You clicked me! 2");
            transform.position = new Vector3(-88, 30, 5);
        }



        if (GUI.Button(new Rect(10, 100, 200, 20), "FrontCameraPosition"))
        {
            Debug.Log("You clicked me! 2");
            transform.position = new Vector3(30, 50, 160);
        }


        if (GUI.Button(new Rect(10, 130, 200, 20), "RightCameraPosition"))
        {
            Debug.Log("You clicked me! 2");
            transform.position = new Vector3(177, 51, 17);
        }

        if (GUI.Button(new Rect(10, 160, 200, 20), "TopCameraPosition"))
        {
            Debug.Log("You clicked me! 2");
            transform.position = new Vector3(25, 100, 12);
        }

        if (GUI.Button(new Rect(10, 190, 200, 20), "FinishLineCameraPosition"))
        {
            Debug.Log("You clicked me! 2");
            transform.position = new Vector3(135, -7, 86);
        }


    }
}