using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    // Start is called before the first frame update
    public string AttackName {get; set;}
    public float Damage {get; set;}
    public string Type {get; set;}
    public float Speed {get; set;}
    public int NumberOfAttacks {get; set;}
    public float Interval {get; set;}
    public string Sprite {get; set;}
    public bool DoubleUp {get; set;}
    public Attack(string attackName, float damage, string type, float speed, int numberOfAttacks, float Interval, string sprite, bool doubleUp) {
        this.AttackName = attackName;
        this.Damage = damage;
        this.Type = type;
        this.Speed = speed;
        this.NumberOfAttacks = numberOfAttacks;
        this.Interval = Interval;
        this.Sprite = sprite;
        this.DoubleUp = doubleUp;
    }
}