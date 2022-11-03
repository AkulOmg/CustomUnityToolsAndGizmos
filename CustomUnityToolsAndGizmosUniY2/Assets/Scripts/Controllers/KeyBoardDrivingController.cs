using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardDrivingController : MonoBehaviour
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
        if (Input.GetKey(KeyCode.W))
        {
            myVehicle.Accelerate();
        }

        //Wait a bit then brake
        if (Input.GetKey(KeyCode.S))
        {
            myVehicle.Brake();
        }


        Debug.Log("Human Observing speed: " + myVehicle.GetSpeed());
    }









}
