using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPickup : Interactable
{

    [SerializeField] Text instructionText;

    public Item item;

    void Start()
    {
        setDestroy();
    }

    public override void Interact()
    {
        base.Interact();

        pickUp();
    }

    void pickUp()
    {
        Debug.Log("Picking up item" + item.name);
        GameManager.Instance.instructionText.text = $"Picked up: {item.name}\nPress 'I' to view\nUse left mouse click to equip/use";
        GameManager.Instance.setInstructionCanvasActive(true);
        // add to inventory
        Debug.Log(Inventory.instance);
        // Inventory.instance.HelloWorld();
        Inventory.instance.Add(item);   // Add to inventory

        if (gameObject.name == "healthPotionTouched")
        {
            GameManager.Instance.healthPotionTouched = true;
        }
        else if (gameObject.name == "SwordTouched")
        {
            GameManager.Instance.SwordTouched = true;
        }
        else if (gameObject.name == "speedPotionTouched")
        {
            GameManager.Instance.speedPotionTouched = true;
        }
        else if (gameObject.name == "legsTouched")
        {
            GameManager.Instance.legsTouched = true;
        }
        else if (gameObject.name == "chestTouched")
        {
            GameManager.Instance.chestTouched = true;
        }
        Destroy(gameObject);
    }

    private void setDestroy()
    {
        if (gameObject.name == "healthPotionTouched" && GameManager.Instance.healthPotionTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "SwordTouched" && GameManager.Instance.SwordTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "speedPotionTouched" && GameManager.Instance.speedPotionTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "legsTouched" && GameManager.Instance.legsTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "chestTouched" && GameManager.Instance.chestTouched)
        {
            Destroy(this.gameObject);
        }
    }
}
