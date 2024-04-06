using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] TextMeshProUGUI StrengthText;
    [SerializeField] TextMeshProUGUI DurabilityText;
    [SerializeField] TextMeshProUGUI DamageText;
    [SerializeField] Text KillText;
    [SerializeField] Text SpareText;

    [SerializeField] public EquippedSlot swordSlot;
    [SerializeField] public EquippedSlot chestSlot;
    [SerializeField] public EquippedSlot legsSlot;

    #region Singleton

    // Static instance of EquipmentManager allows it to be accessed by any other script.
    public static EquipmentManager instance;

    
    // Awake is called when the script instance is being loaded.
    void Awake()
    {
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

    #endregion


    // Reference to the Inventory to interact with it.
    Inventory inventory;

    // Array to hold current equipped items.
    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public event OnEquipmentChanged onEquipmentChanged;

    // intialize the bound of the array to have a fixed number of slot 
    void Start()
    {
        // Get a reference to the Inventory instance.
        inventory = Inventory.instance;

        // Determine the number of slots based on the EquipmentSlot enum.
        int numSlots = 3;

        // Initialize the currentEquipment array based on the number of equipment slots.
        currentEquipment = new Equipment[numSlots];
    }

    // Method to handle equipping a new item.
    public void Equip (Equipment newItem)
    {
        // Find the slot index for the new item based on its equipment type.
        int slotIndex = (int)newItem.equipSlot;

        // Placeholder for an item that will be replaced.
        Equipment pastItem = null;

        if (slotIndex >= 0 && slotIndex < currentEquipment.Length)
        {
            // Check if there is already an item equipped in the slot.
            if (currentEquipment[slotIndex] != null)
            {
                // If so, store the currently equipped item.
                pastItem = currentEquipment[slotIndex];

                // Add the replaced item back to the inventory.
                inventory.Add(pastItem);
            }

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(newItem, pastItem);
            }

        }else
        {
            Debug.LogError("SlotIndex is out of range. Provided index: " + slotIndex);
        }

        // Equip the new item in the specified slot.
        currentEquipment[slotIndex] = newItem;
        Debug.Log("Equip the item");
        
    }


    public void UpdateStatTexts() {
        HealthText.text = GameManager.Instance.PlayerHealth.ToString();
        DurabilityText.text = GameManager.Instance.PlayerDurability.ToString();
        StrengthText.text = GameManager.Instance.PlayerStrength.ToString();
    }

    public void UpdateKillSpare() {
        KillText.text = GameManager.Instance.aliensKilled.ToString();
        SpareText.text = GameManager.Instance.aliensSpared.ToString();
    }
}
