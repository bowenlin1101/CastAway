using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] StartMenuSelector selector;
    private int currentSelection = 0;
    private bool showedControls = false;

    [SerializeField] CanvasGroup XAndZ;
    [SerializeField] CanvasGroup ArrowKeys;
    [SerializeField] CanvasGroup Title;
    [SerializeField] CanvasGroup Buttons;

    [SerializeField] KeyCode ConfirmKey;
    [SerializeField] KeyCode RejectKey;
    private float fadeDuration = 3f;


    // Start is called before the first frame update
    void Start()
    {
        XAndZ.alpha = 0;
        ArrowKeys.alpha = 0;
        Title.alpha = 0;
        Buttons.alpha = 0;
        StartCoroutine(FadeInStartPage());
    }

    // Update is called once per frame
    void Update()
    {
        HandleSelection();
        if (Input.anyKeyDown && !showedControls)
        {
            showedControls = true;
            StartCoroutine(FadeInKeys());
        }
    }

    IEnumerator FadeInKeys()
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

    IEnumerator FadeInStartPage()
    {
        float currentTime = 0f;
        while (currentTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);
            Title.alpha = alpha;
            Buttons.alpha = alpha;
            currentTime += Time.deltaTime;
            yield return null;
        }
        Title.alpha = 1f; // Ensure it's fully visible
        Buttons.alpha = 1f; // Ensure it's fully visible
    }

    void HandleSelection()
    {

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
                GameManager.Instance.movementLocked = false;
            }
            else if (currentSelection == 1)
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}