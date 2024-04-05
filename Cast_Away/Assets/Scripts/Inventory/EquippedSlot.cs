using System;
using UnityEngine;
using UnityEngine.UI;

public class EquippedSlot : MonoBehaviour
{
    private Item item;

    public Image icon;


    public void EquipArmour(Item newItem)
    {
        item = newItem;

        if (newItem == null)
        {
            Debug.LogError("New item is null.");
            return;
        }

        if (newItem.icon == null)
        {
            Debug.LogError("New item's icon is null.");
            return;
        }

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}

