using UnityEngine;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour
{

	public Transform itemsParentInventory;   // The parent object of all the items
	public GameObject inventoryUI;  // The entire UI

	Inventory inventory;    // Our current inventory

	public InventorySlot[] slotsOfInventory;  // List of all the slots

	void Start()
	{

		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

		// Populate our slots array
		slotsOfInventory = itemsParentInventory.GetComponentsInChildren<InventorySlot>();
		
	}



	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI()
	{
		// Loop through all the slots
		for (int i = 0; i < slotsOfInventory.Length; i++)
		{
			if (i < inventory.items.Count)  // If there is an item to add
			{
				slotsOfInventory[i].AddItem(inventory.items[i]);   // Add it
			}
			else
			{
				// Otherwise clear the slot
				slotsOfInventory[i].ClearSlot();
			}
		}

	


	}
}