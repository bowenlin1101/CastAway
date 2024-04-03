using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmptyBoxScript : MonoBehaviour
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
            BoxText.text = "That box was empty!";
            StartCoroutine(ClearTextAfterDelay(1));
        }
    }
    private IEnumerator ClearTextAfterDelay(float delay)
    {

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = false; // Make the object invisible
        }
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        BoxText.text = ""; // Clear the text
        Destroy(gameObject);

    }

}
