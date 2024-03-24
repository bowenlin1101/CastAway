using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenAlienScript : BaseAlienScript
{
    // Start is called before the first frame update

    public CitizenAlienScript() {
        this.Health = 90;
        this.baseHealth = 90;
        this.Species = "Citizen Alien";
        this.Aggression = 100;
        this.baseAggression = 100;
        this.attackDamage = 40;
        this.sprite = Resources.Load<Sprite>("AlienSprites/Comic Battle Royale/2D Character - Alien/Variant A/Sprites/Character/walk/side/01");
    }
    

    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}