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

    public virtual double Attack()
    {
        return 0;
    }
}