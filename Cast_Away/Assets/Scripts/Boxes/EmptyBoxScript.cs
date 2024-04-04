using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmptyBoxScript : MonoBehaviour
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
            GameManager.Instance.instructionText.text = "That box was empty!";
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
        GameManager.Instance.instructionText.text = ""; // Clear the text
        Destroy(gameObject);

    }

}
