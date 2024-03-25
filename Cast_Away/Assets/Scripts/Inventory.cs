using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // this allows to check weather items are recuring in the Invetory or not (Very Important Design Pattern)
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        { 
            Debug.Log("More than one instance in Inventory!");
            return;
        }
        instance = this;
    }

    #endregion

    // creating the callback function using the 
    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    public int poolOfItems = 10;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= poolOfItems)
            {
                // the poolOfItems is larger thn the items of count
                Debug.Log("Not enough room");
                return false;
            }

            // add the item into the List
            items.Add(item);

            // will help update the user UI in the future 
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        // will help update the user UI in the future
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
