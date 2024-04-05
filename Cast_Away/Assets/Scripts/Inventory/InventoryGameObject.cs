using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGameObject : MonoBehaviour
{

	InventoryGameObject instance;

	// Start is called before the first frame update
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

}
