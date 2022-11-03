using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Where the inventory data is saved (save paths)
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]//is what allows you to create a unique class
public class InventoryObject : ScriptableObject //creates the Ui shown on the "inventory inspectors
{
    // Adds to the Inventory UI showing the item in the canvas and updates the number of items shown.
    public List<InventorySlot> Container = new List<InventorySlot>();//is what adds the adjustablity to the inventory through the inspector
    public void AddItem(ItemObject item_, int amount_)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == item_)
            {
                Container[i].AddAmount(amount_);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(item_, amount_));
        }
    }
}

[System.Serializable]//can be edited in inspector (number of inventory slots or items in inventory
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject item_, int amount_)
    {
        item = item_;
        amount = amount_;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}



