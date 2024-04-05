using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     healthPotionTouched1 = false;
     healthPotionTouched2 = false;
     healthPotionTouched3 = false;
     healthPotionTouched4 = false;
     SwordTouched = false;
     speedPotionTouched = false;
     legsTouched = false;
     chestTouched = false;

     closedBox1Touched = false;
     closedBox2Touched = false;
     closedBox3Touched = false;
     closedBox4Touched = false;
     closedBox5Touched = false;
     closedBox6Touched = false;
     closedBox7Touched = false;
     closedBox8Touched = false;
     closedBox9Touched = false;
     closedBox10Touched = false;
     closedBox11Touched = false;
     KeyBoxTouched = false;


     triggeredStartDialogue = false;
    public string currentColor = "blue";
    public int aliensKilled = 0;
    public int aliensSpared = 0;
     Citizen1Touched = false;
     Citizen2Touched = false;
     Citizen3Touched = false;
     Citizen4Touched = false;
     Citizen5Touched = false;
     Doctor1Touched = false;
     Doctor2Touched = false;
     Doctor3Touched = false;
     Doctor4Touched = false;
     Doctor5Touched = false;
     SuperiorTouched = false;
     SuperiorDialogHeard = false;
     movementLocked = false;
    public int keyStatus = 0;
    public int PlayerHealth = 100;
    public int PlayerBaseHealth = 100;
    public int PlayerStrength= 0;
    public int PlayerDurability = 0;
    public Canvas inventoryCanvas;
    public int aliensInteracted = 0;
    public string alienName;
     isInventoryOpen = false;
     swordCollected = false;
    public BaseAlienScript alienToFight;
    public string currentScene;
    public GameObject projectile;
    public float projectileSpeed;
    [SerializeField] public CanvasGroup instructionCanvas;
    [SerializeField] public Text instructionText;
     isInstructionCanvasShowing = false;

    public static GameManager Instance;

    public void setInstructionCanvasActive(bool fadeIn) {
        Debug.Log($"fadeIn: {fadeIn}");
        Debug.Log($"InstructionCanvasShowing: {isInstructionCanvasShowing}");
        if (!isInstructionCanvasShowing && fadeIn) {
            StartCoroutine(FadeInOutInstructions(fadeIn));

        } else if (isInstructionCanvasShowing && !fadeIn) {
            StartCoroutine(FadeInOutInstructions(fadeIn));
        }
    }

    public IEnumerator FadeInOutInstructions(bool fadeIn)
    {
        float currentTime = 0f;

        if (fadeIn) {
            while (currentTime < 0.25f)
            {
                float alpha = Mathf.Lerp(0f, 1f, currentTime / 0.25f);
                instructionCanvas.alpha = alpha;
                currentTime += Time.deltaTime;
                yield return null;
            }
            instructionCanvas.alpha = 1f; // Ensure it's fully visible
            
        } else {
            while (currentTime < 0.25f)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / 0.25f);
                instructionCanvas.alpha = alpha;
                currentTime += Time.deltaTime;
                yield return null;
            }
            instructionCanvas.alpha = 0f; // Ensure it's fully visible
        }

        if (fadeIn) {
            isInstructionCanvasShowing = true;
        } else {
            isInstructionCanvasShowing = false;
        }

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void gotKeyFromAliens()
    {
        if (aliensInteracted == 7)
        {
            keyStatus++;
        }
    }

    public void ResetGame()
    {
        healthPotionTouched1 = false;
        healthPotionTouched2 = false;
        healthPotionTouched3 = false;
        healthPotionTouched4 = false;
        SwordTouched = false;
        speedPotionTouched = false;
        legsTouched = false;
        chestTouched = false;
        triggeredStartDialogue = false;
        currentColor = "blue";
        aliensKilled = 0;
        aliensSpared = 0;
        Citizen1Touched = false;
        Citizen2Touched = false;
        Citizen3Touched = false;
        Citizen4Touched = false;
        Citizen5Touched = false;
        Doctor1Touched = false;
        Doctor2Touched = false;
        Doctor3Touched = false;
        Doctor4Touched = false;
        Doctor5Touched = false;
        SuperiorTouched = false;
        closedBox1Touched = false;
        closedBox2Touched = false;
        closedBox3Touched = false;
        closedBox4Touched = false;
        closedBox5Touched = false;
        closedBox6Touched = false;
        closedBox7Touched = false;
        closedBox8Touched = false;
        closedBox9Touched = false;
        closedBox10Touched = false;
        closedBox11Touched = false;
        KeyBoxTouched = false;
        SuperiorDialogHeard = false;
        movementLocked = false;
        keyStatus = 0;
        PlayerHealth = 100;
        PlayerBaseHealth = 100;
        PlayerStrength= 0;
        PlayerDurability = 0;
        aliensInteracted = 0;
        isInventoryOpen = false;
        swordCollected = false;
        Inventory.instance.items = new List<Item>();
        Inventory.instance.inventoryUI.UpdateUI(Inventory.instance.items);
        EquipmentManager.instance.swordSlot.ClearSlot();
        EquipmentManager.instance.chestSlot.ClearSlot();
        EquipmentManager.instance.legsSlot.ClearSlot();
        movementLocked = true;
       
    }
}
