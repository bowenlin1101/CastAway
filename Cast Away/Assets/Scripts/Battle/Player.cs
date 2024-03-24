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

    public List<Move> attacks;
    // Start is called before the first frame update

    public Player (string name, Sprite sprite) {
        this.Name = name;
        this.attackDamage = 10;
        this.baseHealth = 10;
        this.Health = 10;
        this.attack = 1;
        this.defense = 1;
        this.sprite = sprite;
        attacks = new List<Move>();

        attacks.Add(new Move("Punch", attackDamage*attack, "Physical"));
        attacks.Add(new Move("Kick", attackDamage*attack*2, "Physical"));
        attacks.Add(new Move("Kiss", attackDamage*attack*10, "Emotional"));

        // for (int i = 0; i < attacks.Length; i++) {
        //     attacks[i] = new Move("Punch", attackDamage*attack, "Physical");
        // }
    }

 

    public virtual double Attack()
    {
        return 0;
    }
}