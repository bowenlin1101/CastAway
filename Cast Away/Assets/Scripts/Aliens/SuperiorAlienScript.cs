using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorAlienScript : BaseAlienScript
{

    public SuperiorAlienScript() {
        this.Health = 200;
        this.baseHealth = 200;
        this.Species = "Citizen Alien";
        this.Aggression = 150;
        this.baseAggression = 150;
        this.attackDamage = 70;
        this.sprite = Resources.Load<Sprite>("AlienSprites/Comic Battle Royale/2D Character - Alien/Variant C/Sprites/Character/walk/side/01");
    }
    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}