using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

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
        // add to inventory
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
