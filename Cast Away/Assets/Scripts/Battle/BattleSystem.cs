using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {
    Start, PlayerAction, PlayerAttack, PlayerAct, EnemyMove, Busy
}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] KeyCode ConfirmKey;
    [SerializeField] KeyCode RejectKey;

    [SerializeField] PlayerBattleHud playerHud;
    [SerializeField] PlayerBattleUnit playerUnit;
    [SerializeField] AlienBattleHud alienHud;
    [SerializeField] AlienBattleUnit alientUnit;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;
    int currentAttack;
    int currentAct;

    private void Start() {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle() {
        //Setup Player
        playerUnit.Setup();
        playerHud.SetData(playerUnit.player);
        //Setup Alien
        alientUnit.Setup();
        alienHud.SetData(alientUnit.alien);
        dialogBox.EnableAttackSelector(false);
        dialogBox.EnableActSelector(false);

        //Setup Moves
        dialogBox.SetAttackNames(playerUnit.player.attacks);

        //Setup Acts
        dialogBox.SetActNames(alientUnit.alien.acts);

        //Run dialog Text
        yield return dialogBox.TypeDialog($"You were stopped by {alientUnit.alien.Species}!");
        //Wait for a second
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction() {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
        dialogBox.EnableDialogText(true);
        dialogBox.EnableAttackSelector(false);
        dialogBox.EnableActSelector(false);
    }

    void PlayerAttack() {
        state = BattleState.PlayerAttack;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableAttackSelector(true);
        currentAttack = 0;
    }

    void PlayerAct() {
        state = BattleState.PlayerAct;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActSelector(true);
        currentAct = 0;
    }

    private void Update() {
        if (state == BattleState.PlayerAction) {
            HandleActionSelection();
        } else if (state == BattleState.PlayerAttack) {
            HandleAttackSelection();
        } else if (state == BattleState.PlayerAct) {
            HandleActSelection();
        }
    }

       void HandleActionSelection() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (currentAction < 1)
                ++currentAction;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (currentAction > 0)
                --currentAction;
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(ConfirmKey)) {
            if (currentAction == 0) {
                //Fight
                PlayerAttack();
            } else if (currentAction == 1) {
                //Act
                PlayerAct();
            }
        }
    }


    void HandleActSelection() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (currentAct < alientUnit.alien.acts.Count - 1)
                ++currentAct;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (currentAct > 0)
                --currentAct;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (currentAct < alientUnit.alien.acts.Count -2)
                currentAct += 2;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (currentAct > 1)
                currentAct -= 2;
        }

        if (Input.GetKeyDown(RejectKey)) {
            PlayerAction();
        }

        dialogBox.UpdateActSelection(currentAct, alientUnit.alien.acts[currentAct]);
    }

 
    void HandleAttackSelection() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (currentAttack < playerUnit.player.attacks.Count - 1)
                ++currentAttack;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            if (currentAttack > 0)
                --currentAttack;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (currentAttack < playerUnit.player.attacks.Count -2)
                currentAttack += 2;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (currentAttack > 1)
                currentAttack -= 2;
        }

        if (Input.GetKeyDown(RejectKey)) {
            PlayerAction();
        }

        dialogBox.UpdateAttackSelection(currentAttack, playerUnit.player.attacks[currentAttack]);
    }

}


