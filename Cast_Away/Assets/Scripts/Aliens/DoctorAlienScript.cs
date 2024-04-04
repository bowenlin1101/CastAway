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
        this.attacks = new List<EnemyAttack>();
        this.acts = new List<Move>();
        attacks.Add(new EnemyAttack("Punch", 30, "Physical", 10f, 10, (0.75f, 0.75f, 10), "Fist", 1));
        attacks.Add(new EnemyAttack("Needle Poke", 50, "Physical", 25f, 5, (0.5f, 0.5f, 5), "Needle", 1));
        attacks.Add(new EnemyAttack("Give Bad News", 50, "Physical", 5f, 18, (1.5f, 0.7f, 3), "BadNews", 1));
        acts.Add(new Move("Show Veins", 40, "Emotional", $"You pull your sleeves up against your arms to reveal your killer veins", $"{Species}: Sheeeeesh. What's your workout plan?", $"{Species}: Pshhh, you call those veins? My GRADMA got more veins than that!"));
        acts.Add(new Move("Nurse", 50, "Emotional", $"In a terrible falsetto, you say: \"Oh doctor, the patient is ready\"", "...", $"{Species}: ExCUSe ME??? Do you think this is a joke??"));
        acts.Add(new Move("Do Pushups", 40, "Emotional", $"You drop down and give the cleanest 10 pushups anyone has seen", $"{Species}: So THAT'S how you got those veins. I need to take notes", $"{Species}: Wow, what a show off >:("));
        acts.Add(new Move("Limp", 40, "Emotional", $"You limp around on one leg looking helpless", $"{Species}: Why you poor thing.", $"{Species}: OK I get it. You need help. No need to be so desperate."));

        this.order = new string[3];
        this.order[0] = "Limp";
        this.order[1] = "Show Veins";
        this.order[2] = "Do Pushups";
        this.stage = 0;
    }

      public override (bool, string) TakePacify(Move move) {
        if (this.stage <= this.order.Length && move.MoveName == this.order[this.stage]) {
            this.Aggression -= move.Damage;
            if (this.Aggression < 0) {
                this.Aggression = 0;
            }
            if (this.stage == 2) {
                return (true, move.PosResponse);
            } else {
                stage++;
                return (false, move.PosResponse);
            }
        } else {
            this.stage = 0;
            this.Aggression = baseAggression;
            return (false, move.NegResponse);
        }
    }

    public override double Attack()
    {
        base.Attack();

        return this.attackDamage;
    }
}