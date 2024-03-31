using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBoxScript : MonoBehaviour
{
    public TextMeshProUGUI BoxText;
    public void Start()
    {
        BoxText.text = "";
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (BoxText != null)
        {
            BoxText.text = "You have found the key! Go back to spawn and proceed to level 2.";

        }
        Destroy(gameObject);

    }
}