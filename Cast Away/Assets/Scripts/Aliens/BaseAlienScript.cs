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
    public List<Move> attacks;
    public Sprite sprite;
    // Start is called before the first frame update

    public bool TakeDamage(Move move ) {
        Health -= move.Damage;
        if (Health <= 0) {
            Health = 0;
            return true;
        }
        return false;
    }

    public bool TakePacify(Move move ) {
        Aggression -= move.Damage;
        if (Aggression <= 0) {
            Aggression = 0;
            return true;
        }
        return false;
    }

    public virtual Move generateMove() {
        int n = Random.Range(0, attacks.Count);
        return attacks[n];
    }

    public virtual double Attack()
    {
        return 0;
    }
}