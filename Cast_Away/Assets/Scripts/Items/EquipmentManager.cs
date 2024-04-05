using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] TextMeshProUGUI StrengthText;
    [SerializeField] TextMeshProUGUI DurabilityText;
    [SerializeField] TextMeshProUGUI DamageText;

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

    // Method to unequip an item from a specific slot.
    public void Unequip (int slotIndex)
    {
        // Check if there is an item equipped in the specified slot.
        if (currentEquipment[slotIndex] != null)
        {
            // Store the item that is to be unequipped.
            Equipment pastItem = currentEquipment[slotIndex];

            // Add the unequipped item back to the inventory.
            inventory.Add(pastItem);

            // Remove the item from the equipment slot.
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, pastItem);
            }
        }
    }

    // Method to unequip all items.
    public void UnequipAll()
    {
        // Loop through all equipment slots.
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            // Unequip each item.
            Unequip(i);
        }
    }

    // Update is called once per frame.
    void Update()
    {
        // Check if the 'Q' key is pressed.
        if (Input.GetKeyDown(KeyCode.U))
        {
            // Unequip all items if 'Q' is pressed.
            UnequipAll();
        } 
    }

    public void UpdateStatTexts() {
        HealthText.text = GameManager.Instance.PlayerHealth.ToString();
        DurabilityText.text = GameManager.Instance.PlayerDurability.ToString();
        StrengthText.text = GameManager.Instance.PlayerStrength.ToString();
    }
}
