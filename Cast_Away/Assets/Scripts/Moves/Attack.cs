using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    // Start is called before the first frame update
    public string AttackName {get; set;}
    public float Damage {get; set;}
    public string Type {get; set;}
    public Attack(string AttackName, float Damage, string Type) {
        this.AttackName = AttackName;
        this.Damage = Damage;
        this.Type = Type;
    }
}