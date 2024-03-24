using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] HPBar hpBar;
    // Start is called before the first frame update

    public void SetData(Player player) {
        nameText.text = player.Name;
        hpBar.SetHP(player.Health/ player.baseHealth);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
