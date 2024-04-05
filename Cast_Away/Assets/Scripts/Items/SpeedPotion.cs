using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Item/SpeedPotion")]
public class SpeedPotion : Item
{
    public float speedOfPlayer = 4f;
    public float duration;

    public string description;

    public SpeedPotion(int spModifer, string name, string description)
    {
        this.name = name;
        this.speedOfPlayer = spModifer;
        this.description = description;
    }


    public override void Use()
    {
        base.Use();

        Debug.Log("Using from (SpeedPotion)");
        RemovesFromInventory();
    }
}
