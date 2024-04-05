using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject attackSelector;
    [SerializeField] GameObject attackDetails;
    [SerializeField] GameObject actSelector;
    [SerializeField] GameObject actDetails;
    [SerializeField] GameObject itemSelector;
    [SerializeField] GameObject itemDetails;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> attackTexts;
    [SerializeField] List<Text> actTexts;
    [SerializeField] List<Text> itemTexts;

    [SerializeField] Text attackDescriptionText;
    [SerializeField] Text attackTypeText;
    [SerializeField] Text actDescriptionText;
    [SerializeField] Text actTypeText;

    [SerializeField] GameObject defendSystem;




    public void SetDialog(string dialog) {
        dialogText.text = (dialog);
    }

    public IEnumerator TypeDialog(string dialog) {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray()){
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
    }

    public void EnableDialogText(bool enabled ){
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled ){
        actionSelector.SetActive(enabled);
    }

    public void EnableAttackSelector(bool enabled ){
        attackSelector.SetActive(enabled);
        attackDetails.SetActive(enabled);
    }

    public void EnableActSelector(bool enabled ){
        actSelector.SetActive(enabled);
        actDetails.SetActive(enabled);
    }

    public void EnableItemSelector(bool enabled ){
        itemSelector.SetActive(enabled);
        itemDetails.SetActive(enabled);
    }

    public void EnableDefendSystem(bool enabled ){
        defendSystem.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction) {
        for (int i = 0; i < actionTexts.Count; ++i) {
            if (i == selectedAction) {
                actionTexts[i].color = highlightedColor;
            } else {
                actionTexts[i].color = Color.black;
            }
        }
    }

    public void UpdateAttackSelection(int selectedAttack, Attack attack) {
        for (int i = 0; i < attackTexts.Count; ++i) {
            if (i == selectedAttack) {
                attackTexts[i].color = highlightedColor;
            } else {
                attackTexts[i].color = Color.black;
            }
        }

        attackDescriptionText.text = $"Damage: {attack.Damage}";
        attackTypeText.text = $"Type: {attack.Type}";
    }

    public void UpdateActSelection(int selectedAct, Move move) {
        for (int i = 0; i < actTexts.Count; ++i) {
            if (i == selectedAct) {
                actTexts[i].color = highlightedColor;
            } else {
                actTexts[i].color = Color.black;
            }
        }

        actDescriptionText.text = $"Damage: {move.Damage}";
        actTypeText.text = $"Type: {move.Type}";
    }

    public void UpdateItemSelection(int selectedItem, Item item) {
        for (int i = 0; i < itemTexts.Count; ++i) {
            if (i == selectedItem) {
                itemTexts[i].color = highlightedColor;
            } else {
                itemTexts[i].color = Color.black;
            }
        }

        actDescriptionText.text = $"{((HealthPotion)item).description}";
        actTypeText.text = $"Heal: {((HealthPotion)item).hpHealed}";
    }

    public void SetAttackNames(List<Attack> attacks) {
        for (int i=0; i < attackTexts.Count; i++){
            if (i < attacks.Count) {
                attackTexts[i].text = attacks[i].AttackName;
            } else {
                attackTexts[i].text = "-";
            }
        }
    }

    public void SetActNames(List<Move> acts) {
        for (int i=0; i < actTexts.Count; i++){
            if (i < acts.Count) {
                actTexts[i].text = acts[i].MoveName;
            } else {
                actTexts[i].text = "-";
            }
        }
    }

    public void SetItemNames(List<Item> items) {
        for (int i=0; i < itemTexts.Count; i++){
            if (i < items.Count) {
                itemTexts[i].text = items[i].name;
            } else {
                itemTexts[i].text = "-";
            }
        }
    }
}
