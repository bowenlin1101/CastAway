using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuSelector : MonoBehaviour
{

    [SerializeField] GameObject menuSelector;
    [SerializeField] List<Text> options;
    private Color highlightedColor;
    private bool showedControls = false;

    void Start() {
        UnityEngine.ColorUtility.TryParseHtmlString("#925EF9", out highlightedColor);
    }

    void Update() {
        
    }

    public void UpdateMenuSelection(int selectedAction) {
        for (int i = 0; i < options.Count; ++i) {
            if (i == selectedAction) {
                Debug.Log("set");
                options[i].color = highlightedColor;
            } else {
                options[i].color = Color.white;
            }
        }
    }
}
