using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] StartMenuSelector selector;
    private int currentSelection = 0;
    private bool showedControls = false;

    [SerializeField] CanvasGroup XAndZ;
    [SerializeField] CanvasGroup ArrowKeys;
    [SerializeField] KeyCode ConfirmKey;
    [SerializeField] KeyCode RejectKey;
    public float fadeDuration = 1.0f; 


    // Start is called before the first frame update
    void Start() {
        XAndZ.alpha = 0;
        ArrowKeys.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandleSelection();
        if (Input.anyKeyDown && !showedControls) {
            showedControls = true;
            StartCoroutine(FadeIn());
        }
    }

     IEnumerator FadeIn()
    {
        float currentTime = 0f;
        while (currentTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);
            XAndZ.alpha = alpha;
            ArrowKeys.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }
        XAndZ.alpha = 1f; // Ensure it's fully visible
        ArrowKeys.alpha = 1f; // Ensure it's fully visible
    }

    void HandleSelection() {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSelection < 1)
                currentSelection += 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelection == 1)
                currentSelection -= 1;
        }
        selector.UpdateMenuSelection(currentSelection);

        if (Input.GetKeyDown(ConfirmKey))
        {
            if (currentSelection == 0)
            {
                //Spawn
                SceneManager.LoadScene("Spawn");
            }
            else if (currentSelection == 1)
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
