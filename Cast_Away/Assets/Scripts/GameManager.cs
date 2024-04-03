using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool Citizen1Touched = false;
    public bool Citizen2Touched = false;
    public bool Citizen3Touched = false;
    public bool Citizen4Touched = false;
    public bool Doctor1Touched = false;
    public bool Doctor2Touched = false;
    public bool Doctor3Touched = false;
    public bool SuperiorTouched = false;
    public bool movementLocked = false;
    public int keyStatus = 0;

    public TextMeshProUGUI counter;

    public int aliensInteracted = 0;

    public BaseAlienScript alienToFight;
    public string currentScene;

    public GameObject projectile;
    public float projectileSpeed;

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


    void Update()
    {
        
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
}
