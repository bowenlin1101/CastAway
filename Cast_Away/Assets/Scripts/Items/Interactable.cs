using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // radius of interactable objects
    public float radius = 3f;
    public Transform interactionTransform;

    // is the player focused on collecting interactable
    bool isFocus = false;
    Transform player;

    // check if the player has interacted (not repeat)
    bool hasInteracted = false;

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
                Debug.Log("INTERACTING");
            }
        }
    }

    // virtual method on how the player interacts with objects
    public virtual void Interact()
    {
        // overwritten methods
        Debug.Log("Interacting with  " + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void onDeFocused(Transform playerTransform)
    {
        isFocus = false;
        player = playerTransform;
        hasInteracted = false;
    }

    // draw radius of interaction 
    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null) interactionTransform = transform;
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(interactionTransform.position, radius);
    }
}
