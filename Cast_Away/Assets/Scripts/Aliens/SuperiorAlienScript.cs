using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorAlienScript : BaseAlienScript
{

    public SuperiorAlienScript() {
        this.Health = 450;
        this.baseHealth = 450;
        this.Species = "Superior Alien";
        this.Aggression = 150;
        this.baseAggression = 150;
        this.attackDamage = 70;
        this.sprite = Resources.Load<Sprite>("AlienSprites/Comic Battle Royale/2D Character - Alien/Variant C/Sprites/Character/walk/side/01");
        this.attacks = new List<EnemyAttack>();
        this.acts = new List<Move>();
        attacks.Add(new EnemyAttack("Quick Strike", 100, "Physical", 40f, 3, (1f,1f, 1), "Fist", 1));
        attacks.Add(new EnemyAttack("Acid Rain", 125, "Chemical", 30f, 9, (1f,0.5f, 3), "Acid", 2));
        attacks.Add(new EnemyAttack("Acid Flood", 125, "Chemical", 10f, 30, (0.15f,0.25f, 3), "Acid", 1));
        // attacks.Add(new EnemyAttack("Acid Rain", 125, "Chemical", 30f, 9, (1f,0.5f, 3), "Green ball", 2));
        acts.Add(new Move("Plead", 10, "Emotional", "", "", ""));
        acts.Add(new Move("Appeal", 10, "Emotional", "", "", ""));
        acts.Add(new Move("Flex Muscles", 10, "Emotional", "", "", ""));
        acts.Add(new Move("Challenge", 20, "Emotional", "", "", ""));
    }
    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }

    public override (bool, string) TakePacify(Move move)
    {

        if (GameManager.Instance.aliensKilled < 3)
        {
            Aggression -= move.Damage;
            if (Aggression <= 0)
            {
                Aggression = 0;
                return (true, move.PosResponse);
            }
            return (false, move.PosResponse);
        }
        return (false, move.NegResponse);
    }
}