using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Item/HealthPotion")]
public class HealthPotion : Item

{

    public int hpHealed;
    public string name;

    public string description;

    public HealthPotion(int hpHealed, string name, string description)
    {
        this.name = name;
        this.hpHealed = hpHealed;
        this.description = description;
    }


    public override void Use()
    {
        base.Use();

        Debug.Log("Using from (HealthPotion)");
        RemovesFromInventory();
    }
}