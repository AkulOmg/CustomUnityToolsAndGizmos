using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour//allows the player control keys to be rebined to any other key in the inspector
{
    [SerializeField]
    KeyCode forward = KeyCode.W;

    [SerializeField]
    KeyCode left = KeyCode.A;

    [SerializeField]
    KeyCode backward = KeyCode.S;

    [SerializeField]
    KeyCode right = KeyCode.D;

    [SerializeField]
    KeyCode pickuup = KeyCode.E;

    [SerializeField]
    KeyCode drop = KeyCode.Q;

    [Header("controllable character script")]
    [SerializeField]
    MonoBehaviour target;
    IControllable controlledCharacter;



    // Start is called before the first frame update
    void Start()
    {
        controlledCharacter = target as IControllable;

    }

    // Update is called once per frame
    void Update()//the key pressed changes the direction of the player.
    {
        if (Input.GetKey(forward)) controlledCharacter.Forward();

        if (Input.GetKey(backward)) controlledCharacter.Backward();

        if (Input.GetKey(left)) controlledCharacter.Left();

        if (Input.GetKey(right)) controlledCharacter.Right();

        if (Input.GetKey(drop)) controlledCharacter.Drop();

        if (Input.GetKey(pickuup)) controlledCharacter.Pickup();

    }
}
