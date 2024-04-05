using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPotion : Item

{

    public int hpHealed;
    public string name;

    public string description;

    public HealthPotion(int hpHealed, string name, string description)
    {
        this.name = name;
        this.hpHealed = hpHealed;
        this.description = description;
    }
}