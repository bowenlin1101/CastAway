using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBoxScript : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.instructionText.text = "";
        if (GameManager.Instance.keyStatus > 0) {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Instance.instructionText != null)
        {
            GameManager.Instance.setInstructionCanvasActive(true);
            GameManager.Instance.instructionText.text = "Key found!\nGo back to spawn!";
            GameManager.Instance.keyStatus++;
            Destroy(gameObject);
        }
    }

}