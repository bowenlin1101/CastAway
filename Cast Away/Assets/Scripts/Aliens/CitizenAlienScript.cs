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
        this.attacks = new List<Move>();
        this.acts = new List<Move>();
        attacks.Add(new Move("Punch", 30, "Physical"));
        acts.Add(new Move("Insult", 40, "Emotional"));
        acts.Add(new Move("Talk About Taxes", 50, "Emotional"));
        acts.Add(new Move("Compliment", 40, "Emotional"));
        acts.Add(new Move("Flatter", 40, "Emotional"));
    }
    

    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}