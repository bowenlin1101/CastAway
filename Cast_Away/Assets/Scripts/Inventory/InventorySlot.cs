using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;

    public Image icon;

    public Button removeBtn;

    [SerializeField]
    public EquippedSlot sword, chest, legs;

    private EquipmentSlotType equipmentType;



    public void AddItem(Item newItem)
    {
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

        icon.sprite = item.icon;
        icon.enabled = true;
        removeBtn.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeBtn.interactable = false;
    }

    public void onRemoveBtn()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if (item is Equipment)
            {
                this.equipmentType = ((Equipment)item).equipmentType;
                EquipGear();
                
            }else {
                GameManager.Instance.PlayerHealth += ((HealthPotion)item).hpHealed;
            }

            item.Use();
        }
    }

    void EquipGear()
    {
        if (equipmentType != null)
        {
            // Assuming you're trying to equip based on the type of equipment.
            Debug.Log("Type: " + equipmentType);
            switch (equipmentType)
            {
                case EquipmentSlotType.Sword:
                    // Equip the sword here
                    sword.EquipArmour(item);
                    Debug.Log($"equipmentType {equipmentType}");
                    break;
                case EquipmentSlotType.Chest:
                    // Equip the chest gear here
                    chest.EquipArmour(item);
                    Debug.Log($"equipmentType {equipmentType}");
                    break;
                case EquipmentSlotType.Legs:
                    // Equip the legs gear here
                    legs.EquipArmour(item);
                    Debug.Log($"equipmentType {equipmentType}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            Debug.Log($"equipmentType {equipmentType}");
            throw new NullReferenceException();

        }

    }
}

