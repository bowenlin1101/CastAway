using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Equipment", menuName ="Inventory/Equipment")]

public class Equipment : Item
{
    public int equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        // equip the item remove it from main inventory or holding slot
        EquipmentManager.instance.Equip(this);
        RemovesFromInventory();
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet};