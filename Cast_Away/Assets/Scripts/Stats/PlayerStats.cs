using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	This component is derived from CharacterStats. It adds two things:
		- Gaining modifiers when equipping items
		- Restarting the game when dying
*/

public class PlayerStats : CharacterStat
{

	// Use this for initialization
	public override void Start()
	{

		base.Start();
		if (EquipmentManager.instance != null)
		{
			EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
		}
		else
		{
			Debug.LogError("EquipmentManager instance is null.");
		}

		armor = new Stat();
		damage = new Stat();

	}

  

    void onEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.AddModifier(newItem.armorModifier);
			damage.AddModifier(newItem.damageModifier);
		}

		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armorModifier);
			damage.RemoveModifier(oldItem.armorModifier);
		}

	}



}