using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGizmo : MonoBehaviour
{
    void OnDrawGizmosSelected()//Only appears when selected
    {
        Gizmos.DrawIcon(transform.position, "SurprizedShaq.png");
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(5, 5, 5));//numbers decide size perameters. will be based on whever the game object is


    }

    void OnDrawGizmos()//To draw the gizmos
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector3(1, 1, 1), new Vector3(1, 1, 1)); //Specifying the location in the scene
        
    }


}
