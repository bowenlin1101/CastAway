using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

// this will allow you to create a new Item Object from the window of the Unity
public class Item : ScriptableObject
{
    // these can be set based on the items implementation
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    
}
