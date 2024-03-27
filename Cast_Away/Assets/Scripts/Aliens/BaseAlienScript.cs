using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAlienScript
{
    public string Species;
    public float attackDamage;
    public float baseHealth;
    public float Health;
    public float baseAggression;
    public float Aggression;
    public List<Move> acts;
    public List<Attack> attacks;

    public int stage;

    public string[] order;
    public Sprite sprite;
    // Start is called before the first frame update

    public bool TakeDamage(Attack attack ) {
        Health -= attack.Damage;
        if (Health <= 0) {
            Health = 0;
            return true;
        }
        return false;
    }

    public virtual (bool, string) TakePacify(Move move ) {
        Aggression -= move.Damage;
        if (Aggression <= 0) {
            Aggression = 0;
            return (true, move.PosResponse);
        }
        return (false, move.PosResponse);
    }

    public virtual Attack generateAttack() {
        int n = Random.Range(0, attacks.Count);
        return attacks[n];
    }

    public virtual double Attack()
    {
        return 0;
    }
}