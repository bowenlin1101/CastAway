using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// make the stat hidden from the player
[System.Serializable]
public class Stat
{
    public int baseValue;

    private List<int> modifiers = new List<int>();

    public int getValue()
    {
        return baseValue;
    }

    public void AddModifer(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
