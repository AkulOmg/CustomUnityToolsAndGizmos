using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Player Inventory Script (Collect items)

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    //object added to inventory is destroyed after being added 
    private void OnTriggerEnter(Collider collision)
    {
        var item = collision.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();//when the game ends the contense of the inventory will empty befor the next game starts.
    }


}