using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAlienScript : BaseAlienScript
{

    public DoctorAlienScript() {
        this.Health = 70;
        this.baseHealth = 70;
        this.Species = "Doctor Alien";
        this.Aggression = 100;
        this.baseAggression = 100;
        this.attackDamage = 20;
        this.sprite = Resources.Load<Sprite>("AlienSprites/Comic Battle Royale/2D Character - Alien/Variant B/Sprites/Character/walk/side/01");
        this.attacks = new List<Move>();
        this.acts = new List<Move>();
        attacks.Add(new Move("Punch", 30, "Physical"));
        acts.Add(new Move("Show Veins", 40, "Emotional"));
        acts.Add(new Move("Nurse Impression", 50, "Emotional"));
        acts.Add(new Move("Do Pushups", 40, "Emotional"));
        acts.Add(new Move("Limp", 40, "Emotional"));
    }


    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}