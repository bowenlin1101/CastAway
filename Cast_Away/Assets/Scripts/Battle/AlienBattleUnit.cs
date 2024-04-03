using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienBattleUnit : MonoBehaviour
{
    public BaseAlienScript alien {get; set;}

    public void Setup() {
        alien = GameManager.Instance.alienToFight;
        GetComponent<Image>().sprite = alien.sprite;
    }
}
