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
        this.attacks = new List<Move>();
        this.acts = new List<Move>();
        attacks.Add(new Move("Hammer Spin", 100, "Physical"));
        attacks.Add(new Move("Acid Rain", 150, "Chemical"));
        acts.Add(new Move("Plead", 40, "Emotional"));
        acts.Add(new Move("Appeal", 50, "Emotional"));
        acts.Add(new Move("Flex Muscles", 40, "Emotional"));
        acts.Add(new Move("Challenge Authority", 40, "Emotional"));
    }
    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}