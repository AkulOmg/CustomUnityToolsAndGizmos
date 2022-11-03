using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, IPickable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(180.0f * Time.deltaTime, 0.0f, 0.0f);
    }

    public void Pickup()
    {
        gameObject.SetActive(false);
    }

    public void Drop(Vector3 location)
    {
        transform.position = location;
        gameObject.SetActive(true);
    }



}
