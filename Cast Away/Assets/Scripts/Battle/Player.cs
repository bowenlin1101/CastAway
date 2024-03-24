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
    // Start is called before the first frame update

    public Player (string name, Sprite sprite) {
        this.Name = name;
        this.attackDamage = 10;
        this.baseHealth = 10;
        this.Health = 10;
        this.attack = 1;
        this.defense = 1;
        this.sprite = sprite;
    }

 

    public virtual double Attack()
    {
        return 0;
    }
}