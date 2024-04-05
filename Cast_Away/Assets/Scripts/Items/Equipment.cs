using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    public int equipSlot;

    public int armorModifier;
    public int damageModifier;

    [SerializeField]
    internal EquipmentSlotType equipmentType;

    public override void Use()
    {
        base.Use();
        // equip the item remove it from main inventory or holding slot
        Debug.Log("Using (Equipment)");
        EquipmentManager.instance.Equip(this);
        RemovesFromInventory();
    }
}

public enum EquipmentSlotType { Sword, Chest, Legs };