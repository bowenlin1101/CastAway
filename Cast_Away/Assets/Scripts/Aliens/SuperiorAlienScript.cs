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
        this.attacks = new List<Attack>();
        this.acts = new List<Move>();
        attacks.Add(new Attack("Hammer Spin", 100, "Physical", 20f, 3, 1f, "Hammer"));
        attacks.Add(new Attack("Acid Rain", 150, "Chemical", 35f, 20, 0.25f, "Green ball"));
        acts.Add(new Move("Plead", 10, "Emotional", "", "", ""));
        acts.Add(new Move("Appeal", 10, "Emotional", "", "", ""));
        acts.Add(new Move("Flex Muscles", 10, "Emotional", "", "", ""));
        acts.Add(new Move("Challenge Authority", 20, "Emotional", "", "", ""));
    }
    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}