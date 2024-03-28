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
        this.attacks = new List<Attack>();
        this.acts = new List<Move>();
        attacks.Add(new Attack("Punch", 30, "Physical", 5f, 5, 2f, "Fist", true));
        attacks.Add(new Attack("Throw Pennies", 50, "Physical", 10f, 10, 1f, "Penny", false));
        acts.Add(new Move("Insult", 40, "Emotional", $"You tell {Species} he has no friends.", $"{Species}: Thanks I really needed some honesty. I've been trying to tell myself that for weeks :)", $"{Species}: Well YOU have no friends either"));
        acts.Add(new Move("Discuss Taxes", 50, "Emotional", $"You complain to {Species} about the increasing tax rates", $"{Species}: FINALLY, someone who understands where I'm coming from", $"{Species}: Yeah, well it's not like you pay taxes"));
        acts.Add(new Move("Compliment", 40, "Emotional", $"You tell {Species} you like his hat", "...", $"{Species}: I'm not wearing a hat... >:("));
        acts.Add(new Move("Flatter", 40, "Emotional", $"You wink at {Species} and tell him he looks like a million bucks", $"{Species}: In this economy??? Stopppp ;)", $"{Species}: Uhhh.... I have a boyfriend..."));
        this.order = new string[3];
        this.order[0] = "Flatter";
        this.order[1] = "Discuss Taxes";
        this.order[2] = "Insult";
        this.stage = 0;
    }

    public override (bool, string) TakePacify(Move move) {
        if (move.MoveName == this.order[this.stage]) {
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