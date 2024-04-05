using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

	[SerializeField] InventoryUI inventoryUI;


	#region Singleton

	public static Inventory instance;

	// Start is called before the first frame update
    void Awake()
    {
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	#endregion


	public int space = 6;  // Amount of slots in inventory

	// Current list of items in inventory
	public List<Item> items = new List<Item>();

	// Add a new item. If there is enough room we
	// return true. Else we return false.
	public bool Add(Item item)
	{
		// Don't do anything if it's a default item
		Debug.Log(item);
		if (!item.isDefaultItem)
		{
			// Check if out of space
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}

			items.Add(item);    // Add item to list
			inventoryUI.UpdateUI(items);

		}

		return true;
	}

	public void HelloWorld() {
		Debug.Log("Hello World");
	}

	// Remove an item
	public void Remove(Item item)
	{
		items.Remove(item);     // Remove item from list
		inventoryUI.UpdateUI(items);

	}
}