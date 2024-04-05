using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;

    public override void Interact()
    {
        base.Interact();

        pickUp();
    }

    void pickUp()
    {
        Debug.Log("Picking up item" + item.name);
        // add to inventory
        Inventory.instance.Add(item);   // Add to inventory

        Destroy(gameObject);	// Destroy item from scene
    }
}
