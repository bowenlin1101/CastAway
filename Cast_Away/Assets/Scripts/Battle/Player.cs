using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Sprite sprite;
    public string Name;
    public float attackDamage;
    public float baseHealth;
    public float Health;
    public float attack;
    public float defense;

    public List<Attack> attacks;

    public List<Item> items;
    // Start is called before the first frame update

    public Player (string name, Sprite sprite) {
        this.Name = name;
        this.attackDamage = 10;
        this.baseHealth = 100;
        this.Health = 1;
        this.attack = 1;
        this.defense = 1;
        this.sprite = sprite;
        attacks = new List<Attack>();
        items = new List<Item>();
        attacks.Add(new Attack("Punch", attackDamage*attack, "Physical"));
        attacks.Add(new Attack("Kick", attackDamage*attack*2, "Physical"));
        attacks.Add(new Attack("Kiss", attackDamage*attack*10, "Emotional"));

        items.Add(new HealthPotion(50, "Small Potion", "Heals"));
        items.Add(new HealthPotion(50, "Small Potion", "Heals"));
        items.Add(new HealthPotion(50, "Small Potion", "Heals"));
        items.Add(new HealthPotion(50, "Small Potion", "Heals"));
    }

    public bool TakeDamage(float damage ) {
        Health -= damage;
        if (Health <= 0) {
            Health = 0;
            return true;
        } else if (Health > baseHealth) {
            Health = baseHealth;
        }
        return false;
    }

 

    public virtual double Attack()
    {
        return 0;
    }
}