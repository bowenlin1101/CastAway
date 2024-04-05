using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool triggeredStartDialogue = false;
    public string currentColor = "blue";
    public int aliensKilled = 0;
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

    public int aliensInteracted = 0;
    public string alienName;

    public BaseAlienScript alienToFight;
    public string currentScene;
    public GameObject projectile;
    public float projectileSpeed;
    [SerializeField] public Canvas instructionCanvas;
    [SerializeField] public Text instructionText;

    public static GameManager Instance;

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

    public void gotKeyFromBox()
    {
        keyStatus++;
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
        triggeredStartDialogue = false;
        currentColor = "blue";
        aliensKilled = 0;
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
        aliensInteracted = 0;
    }
}
