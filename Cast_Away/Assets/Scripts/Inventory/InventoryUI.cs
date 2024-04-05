using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour
{

	public Transform itemsParentInventory;   // The parent object of all the items
	Inventory inventory;    // Our current inventory
    public static InventoryUI instance;
    public InventorySlot[] slotsOfInventory;  // List of all the slots

	void Start()
	{

		inventory = Inventory.instance;

		// Populate our slots array
		slotsOfInventory = itemsParentInventory.GetComponentsInChildren<InventorySlot>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	public void UpdateUI(List<Item> items)
	{
		for (int i = 0; i < slotsOfInventory.Length; i++)
		{
			if (i < items.Count)  // If there is an item to add
			{
				slotsOfInventory[i].AddItem(items[i]);   // Add it
			}
			else
			{
				// Otherwise clear the slot
				slotsOfInventory[i].ClearSlot();
			}
		}
		Debug.Log("UPdated IU");
	}
}