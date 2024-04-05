using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
        armor = new Stat();
        damage = new Stat();

    }

    // add and remove modifier once the item is equipped 
    void onEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            if (armor != null)
            {
                armor.AddModifer(newItem.armorModifier);
            }
            if (damage != null)
            {
                damage.AddModifer(newItem.damageModifier);
            }
        }

        if (oldItem != null)
        {
            if (armor != null)
            {
                armor.RemoveModifier(oldItem.armorModifier);
            }
            if (damage != null)
            {
                damage.RemoveModifier(oldItem.damageModifier);
            }
        }

    }
}
