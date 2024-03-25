using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

// this will allow you to create a new Item Object from the window of the Unity
public class Item : ScriptableObject
{
    // these can be set based on the items implementation
    new public string name = "New Item"; // name of item
    public Sprite icon = null; // icon of item
    public bool isDefaultItem = false; // is the item defualt to the player


    // Called when the Item is used from either inventory or picked up by player
    public virtual void Use()
    {

        Debug.Log("Using " + name); 
    }

    public void RemovesFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
