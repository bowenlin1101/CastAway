using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBoxScript : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.instructionText.text = "";
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Instance.instructionText != null)
        {
            GameManager.Instance.instructionText.text = "Key found! Go back to spawn!";

        }

        GameManager.Instance.gotKeyFromBox();
        Debug.Log(GameManager.Instance.keyStatus);
        Destroy(gameObject);

    }

}