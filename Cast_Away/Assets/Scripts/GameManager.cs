using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool firstAlienTouched = false;
    public bool movementLocked = false;
    public int keyStatus = 0;

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
