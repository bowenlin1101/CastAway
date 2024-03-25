using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer; // Add this line to hold a reference to the SpriteRenderer

    // Add a public Sprite field to assign the new sprite in the inspector
    public Sprite playerSprite;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Set the sprite to the spriteRenderer component at the start
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>(); // Make sure to grab the reference if not set

        if (playerSprite != null)
            spriteRenderer.sprite = playerSprite; // Set the sprite on the SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    // Call this method to change the player's sprite at runtime
    public void SetPlayerSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}
