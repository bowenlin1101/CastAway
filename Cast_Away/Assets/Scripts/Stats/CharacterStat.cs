using UnityEngine;

/* Contains all the stats for a character. */

public class CharacterStat : MonoBehaviour
{

	public Stat maxHealth;          // Maximum amount of health
	public int currentHealth { get; protected set; }    // Current amount of health

	public Stat damage;
	public Stat armor;

	public event System.Action OnHealthReachedZero;

	public virtual void Awake()
	{
		currentHealth = maxHealth.GetValue();
	}

	// Start with max HP.
	public virtual void Start()
	{
		maxHealth.AddModifier(100);
	}


	// Heal the character.
	public void Heal(int amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
	}



}