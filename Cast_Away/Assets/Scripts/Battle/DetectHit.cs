using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectHit : MonoBehaviour

{
    public int hits = 0;
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        Debug.Log("hit something");
        // Check if the collided object is a projectile
        if (collider.CompareTag("Projectile"))
        {
            // Handle player being hit by the projectile
            Debug.Log("Player hit by projectile!");
            Destroy(collider.gameObject,0f);
            hits++;
            // Add any necessary logic here (e.g., reduce player health, play hit animation, etc.)
        }
    }
}
