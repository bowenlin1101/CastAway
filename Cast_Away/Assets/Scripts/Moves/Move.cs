using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Start is called before the first frame update
    public string MoveName {get; set;}
    public float Damage {get; set;}
    public string Type {get; set;}
    public string Description {get; set;}
    public string PosResponse {get; set;}
    public string NegResponse {get; set;}
    public Move(string attackName, float damage, string type, string description, string posResponse, string negResponse) {
        this.MoveName = attackName;
        this.Damage = damage;
        this.Type = type;
        this.Description = description;
        this.PosResponse = posResponse;
        this.NegResponse = negResponse;
    }
}