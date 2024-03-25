using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Start is called before the first frame update
    public string MoveName {get; set;}
    public float Damage {get; set;}
    public string Type {get; set;}
    public Move(string attackName, float damage, string type) {
        this.MoveName = attackName;
        this.Damage = damage;
        this.Type = type;
    }
    
}