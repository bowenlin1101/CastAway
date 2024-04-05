using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Item/StrengthPotion")]
public class StrengthPotion : Item
{
    public int strengthOfPlayer;

    public string description;

    

    public StrengthPotion(int stModifer, string name, string description)
    {
        this.name = name;
        this.strengthOfPlayer = stModifer;
        this.description = description;
    }


    public override void Use()
    {
        base.Use();

        Debug.Log("Using from (SpeedPotion)");
        RemovesFromInventory();
    }
}
