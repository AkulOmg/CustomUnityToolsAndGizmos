using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayUI : MonoBehaviour
{
    public InventoryObject inventory;
    //where the inventory HUD is located.
    public int XStart;
    public int YStart;
    //This code would allow for more than one inventory item to be shown at a given time. the public values below would change the formate if there were more items in the inventry.
    public int XBetweenItem;
    public int NumberOfColumn;
    public int YSpaceBetweenItems;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
       UpdateDisplay(); // updates the value in the player inventory when item picked up
    }
    public void UpdateDisplay()//Updates the isplay when a item is picked
    {
        for (int i = 0; i < inventory.Container.Count; i++)//adds the item into the inventory via an array
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");//The "n0" will keep the format of the numbers from changing fonts or overlapping boxes
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
    public void CreateDisplay() //creates the UI on screen 
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }

    }

    public Vector3 GetPosition(int i) //the position of this information can be adjusted in the inspector.
    {
        return new Vector3(XStart + (XBetweenItem * (i % NumberOfColumn)), YStart + (-YSpaceBetweenItems * (i / NumberOfColumn)), 0f);
    }
}
