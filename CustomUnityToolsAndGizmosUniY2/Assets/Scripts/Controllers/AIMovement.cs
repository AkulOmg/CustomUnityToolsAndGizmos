using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.AI; //What makes AI movement Posible

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private Transform goal;

    private void Start()
    {

        var AIMovement = GetComponent<NavMeshAgent>();
        AIMovement.destination = goal.position;
    }
}