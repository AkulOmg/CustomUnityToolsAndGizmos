using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    void OnDrawGizmos()//To draw the gizmos
    {
        Gizmos.color = Color.red;

        /*Gizmos.DrawSphere(transform.position, 1.5f);//Creates the 3d shape*/
        Gizmos.DrawWireSphere(transform.position, 2f);//Creates the wireframe shape

        //Specifying the matrix
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation,
            transform.lossyScale);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 1f, 1f));

    }
}
