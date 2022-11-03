using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDrivingController : MonoBehaviour
{

    [SerializeField]
    MonoBehaviour target;

    IDrivable myVehicle;


    // Start is called before the first frame update
    void Start()
    {
        myVehicle = target as IDrivable;

    }

    // Update is called once per frame
    void Update()
    {
        Drive();
    }

    void Drive()
    {
        //Accselerate for 5 secs
        if (Time.time < 5.0f)
        {
            myVehicle.Accelerate();
        }

        //Wait a bit then brake
        if (Time.time > 7.0f)
        {
            myVehicle.Brake();
        }


        Debug.Log("AI Observing speed: " + myVehicle.GetSpeed());
    }









}