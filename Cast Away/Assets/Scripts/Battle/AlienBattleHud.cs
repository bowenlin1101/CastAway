using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienBattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] HPBar hpBar;
    [SerializeField] ABar aBar;
    // Start is called before the first frame update

    public void SetData(BaseAlienScript alien) {
        nameText.text = alien.Species;
        hpBar.SetHP(alien.Health/ alien.baseHealth);
        aBar.SetAggression(alien.Aggression/alien.baseAggression);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
