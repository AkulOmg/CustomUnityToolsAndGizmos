using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Copy pasta from original wk3 try

public class VehicleBehaviour : MonoBehaviour, IDrivable
{
    float currentSpeed;

    [SerializeField]
    float acceleration = 2.0f;

    [SerializeField]
    float drag = 0.0001f;



    //start called before frame
    void Start()
    {

    }

    //Update 1x frame
    void Update()
    {
        transform.position += new Vector3(currentSpeed * Time.deltaTime, 0.0f, 0.0f);

        currentSpeed -= currentSpeed * drag * Time.deltaTime;

    }

    //Implements drivable interface
    public void Accelerate()
    {
        currentSpeed += acceleration * Time.deltaTime;
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }


    public void Brake()
    {
        currentSpeed -= acceleration * Time.deltaTime;
        if (currentSpeed < 0.0f)
        {
            currentSpeed = 0.0f;
        }

        GetComponent<Renderer>().material.SetColor("_Color", Color.red);

    }




    public float GetSpeed()
    {
        return currentSpeed;
    }


}
