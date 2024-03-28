using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{
    public float Speed {get; set;}
    public int NumberOfAttacks {get; set;}
    public (float, float) Interval {get; set;}
    public string Sprite {get; set;}
    public int AttackPattern {get; set;}
    public EnemyAttack(string attackName, float damage, string type, float speed, int numberOfAttacks, (float, float) Interval, string sprite, int attackPattern) : base(attackName, damage, type) {
        this.Speed = speed;
        this.NumberOfAttacks = numberOfAttacks;
        this.Interval = Interval;
        this.Sprite = sprite;
        this.AttackPattern = attackPattern;
    }
}