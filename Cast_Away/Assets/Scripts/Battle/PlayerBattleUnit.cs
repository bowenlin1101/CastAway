using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleUnit : MonoBehaviour
{
    public Player player {get; set;}

    public void Setup() {
        Sprite mySprite;
        Sprite blueSprite = Resources.Load<Sprite>("CharacterSprite/Comic Battle Royale/2D Character - Astronaut/Variant A/Sprites/Character/walk/side/01");
        Sprite redSprite = Resources.Load<Sprite>("CharacterSprite/Comic Battle Royale/2D Character - Astronaut/Variant B/Sprites/Character/walk/side/01");
        Sprite greenSprite = Resources.Load<Sprite>("CharacterSprite/Comic Battle Royale/2D Character - Astronaut/Variant C/Sprites/Character/walk/side/01");
        Sprite yellowSprite = Resources.Load<Sprite>("CharacterSprite/Comic Battle Royale/2D Character - Astronaut/Variant D/Sprites/Character/walk/side/01");
        Sprite pinkSprite = Resources.Load<Sprite>("CharacterSprite/Comic Battle Royale/2D Character - Astronaut/Variant E/Sprites/Character/walk/side/01");
        string currentColor = GameManager.Instance.currentColor;

        switch (currentColor) {
            case "blue":
                mySprite = blueSprite;
                break;
            case "red":
                mySprite = redSprite;
                break;
            case "green":
                mySprite = greenSprite;
                break;
            case "yellow":
                mySprite = yellowSprite;
                break;
            case "pink":
                mySprite = pinkSprite;
                break;
            default:
                mySprite = blueSprite;
                break;
        }
        if (mySprite != null) {

        } else {
            Debug.LogError("Sprite not Loaded");
        }
        
        player = new Player("brosky", mySprite);
        Image image = GetComponent<Image>();
        image.sprite = player.sprite;
        image.rectTransform.localScale = new Vector3(-image.rectTransform.localScale.x, image.rectTransform.localScale.y, image.rectTransform.localScale.z);
    }
}
