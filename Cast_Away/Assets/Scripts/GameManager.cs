using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool healthPotionTouched = false;
    public bool SwordTouched = false;
    public bool speedPotionTouched = false;
    public bool legsTouched = false;
    public bool chestTouched = false;

    public bool triggeredStartDialogue = false;
    public string currentColor = "blue";
    public int aliensKilled = 0;
    public int aliensSpared = 0;
    public bool Citizen1Touched = false;
    public bool Citizen2Touched = false;
    public bool Citizen3Touched = false;
    public bool Citizen4Touched = false;
    public bool Citizen5Touched = false;
    public bool Doctor1Touched = false;
    public bool Doctor2Touched = false;
    public bool Doctor3Touched = false;
    public bool Doctor4Touched = false;
    public bool Doctor5Touched = false;
    public bool SuperiorTouched = false;
    public bool SuperiorDialogHeard = false;
    public bool movementLocked = false;
    public int keyStatus = 0;
    public int PlayerHealth = 100;
    public int PlayerBaseHealth = 100;
    public int PlayerStrength= 0;
    public int PlayerDurability = 0;
    public Canvas inventoryCanvas;
    public int aliensInteracted = 0;
    public string alienName;
    public bool isInventoryOpen = false;
    public bool swordCollected = false;
    public BaseAlienScript alienToFight;
    public string currentScene;
    public GameObject projectile;
    public float projectileSpeed;
    [SerializeField] public CanvasGroup instructionCanvas;
    [SerializeField] public Text instructionText;
    public bool isInstructionCanvasShowing = false;

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
        healthPotionTouched = false;
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
    }
}
