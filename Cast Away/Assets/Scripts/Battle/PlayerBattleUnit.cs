using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleUnit : MonoBehaviour
{
    public Player player {get; set;}

    public void Setup() {
        Sprite mySprite = Resources.Load<Sprite>("CharacterSprite/Comic Battle Royale/2D Character - Astronaut/Variant A/Sprites/Character/walk/side/01");
        
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
