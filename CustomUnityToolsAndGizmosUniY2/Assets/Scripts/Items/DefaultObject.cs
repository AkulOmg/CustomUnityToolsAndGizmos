using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of inventory set up
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")] 
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}

//this is where would would be abe l e to crate dfiffrent inventory object types . Allows for  unlimited number of items to be added in by following the format