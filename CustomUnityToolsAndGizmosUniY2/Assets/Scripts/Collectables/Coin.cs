using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 180.0f * Time.deltaTime, 0.0f); /*Rotates the pickable item on the spot.*/
    }

    public void Pickup()
    {
        gameObject.SetActive(false); //when item picked up it will not longer be visable
    }

    public void Drop(Vector3 location) //the item picked up will drop in the order it was picked up
    {
        transform.position = location;
        gameObject.SetActive(true);
    }



}