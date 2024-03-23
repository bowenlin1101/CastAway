using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth { get; private set; }

    // stat buffs/equipable items
    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // get the damage done from the armour first 
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // subtract the damage from the current health
        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage");

        // if health is less than 0 then die
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // die in some way will be unique to case

        Debug.Log(transform.name + "died");
    }
}
