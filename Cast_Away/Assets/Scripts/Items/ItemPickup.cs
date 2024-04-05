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

        if (gameObject.name == "HealthPotion1")
        {
            GameManager.Instance.healthPotionTouched1 = true;
        } else if (gameObject.name == "HealthPotion2")
        {
            GameManager.Instance.healthPotionTouched2 = true;
        }
        else if (gameObject.name == "HealthPotion3")
        {
            GameManager.Instance.healthPotionTouched3 = true;
        }
        else if (gameObject.name == "HealthPotion4")
        {
            GameManager.Instance.healthPotionTouched4 = true;
        }
        else if (gameObject.name == "Sword")
        {
            GameManager.Instance.SwordTouched = true;
        }
        else if (gameObject.name == "SpeedPotion")
        {
            GameManager.Instance.speedPotionTouched = true;
        }
        else if (gameObject.name == "Legs")
        {
            GameManager.Instance.legsTouched = true;
        }
        else if (gameObject.name == "Chest")
        {
            GameManager.Instance.chestTouched = true;
        }
        Destroy(gameObject);
    }

    private void setDestroy()
    {
        if (gameObject.name == "HealthPotion1" && GameManager.Instance.healthPotionTouched1)
        {
            Destroy(this.gameObject);
        } else if (gameObject.name == "HealthPotion2" && GameManager.Instance.healthPotionTouched2)
        {
            Destroy(this.gameObject);
        } else if (gameObject.name == "HealthPotion3" && GameManager.Instance.healthPotionTouched3)
        {
            Destroy(this.gameObject);
        } else if (gameObject.name == "HealthPotion4" && GameManager.Instance.healthPotionTouched4)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "Sword" && GameManager.Instance.SwordTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "SpeedPotion" && GameManager.Instance.speedPotionTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "Legs" && GameManager.Instance.legsTouched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "Chest" && GameManager.Instance.chestTouched)
        {
            Destroy(this.gameObject);
        }
    }
}
