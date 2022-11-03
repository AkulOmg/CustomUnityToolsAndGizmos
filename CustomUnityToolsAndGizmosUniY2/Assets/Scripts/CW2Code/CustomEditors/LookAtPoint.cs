using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class LookAtPoint : MonoBehaviour
{

    public Transform target;
    

    public void Update()
    {
        transform.LookAt(target);

       
    }
}
