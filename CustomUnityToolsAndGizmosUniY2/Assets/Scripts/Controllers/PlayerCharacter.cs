using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IControllable
{
    [SerializeField]
    float speed = 10.0f;

    [SerializeField]
    float rotationSpeed = 45.0f;



    List<IPickable> pickedItems = new List<IPickable>();

    float LastDroppedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Forward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void Backward()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
    }

    public void Left()
    {
        transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
    }

    public void Right()
    {
        transform.Rotate(0.0f, +rotationSpeed * Time.deltaTime, 0.0f);
    }



    public void Pickup()// picks up the objects and putes them into an array to be used /put back later.
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (var col in colliders)
        {
            IPickable pickableObject = col.GetComponent<IPickable>();

            if (pickableObject != null)
            {
                pickableObject.Pickup();
                pickedItems.Add(pickableObject);
            }
        }
    }

    public void Drop() //is what alolows the items to be droped back into the game in the same order they were picked up
    {
        if (pickedItems.Count > 0 && Time.time > LastDroppedTime + 1.0f)
        {
            IPickable lastItem = pickedItems[pickedItems.Count - 1];
            pickedItems.RemoveAt(pickedItems.Count - 1);
            lastItem.Drop(transform.position);

            LastDroppedTime = Time.time; //stops the user from being able to spam or drop all the item
        }
    }



}