using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] PlayerBattleHud playerHud;
    [SerializeField] PlayerBattleUnit playerUnit;
    [SerializeField] AlienBattleHud alienHud;
    [SerializeField] AlienBattleUnit alientUnit;

    private void Start() {
        SetupBattle();
    }

    public void SetupBattle() {
        playerUnit.Setup();
        playerHud.SetData(playerUnit.player);
        alientUnit.Setup();
        alienHud.SetData(alientUnit.alien);
    }
}
