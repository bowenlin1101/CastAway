using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool Citizen1Touched = false;
    public bool Doctor1Touched = false;
    public bool Citizen2Touched = false;
    public bool Citizen3Touched = false;
    public bool movementLocked = false;
    public int keyStatus = 0;

    public int aliensInteracted = 0;

    public BaseAlienScript alienToFight;

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

    public void gotKey()
    {
        keyStatus++;
    }
}
