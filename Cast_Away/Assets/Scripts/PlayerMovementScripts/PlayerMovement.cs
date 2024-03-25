using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer spriteRenderer; 
    public Sprite playerSprite;

    Vector2 movement;

    void Start()
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("C:\\Users\\hamza\\Final Project\\Cast_Away\\Assets\\Resources\\CharacterSprite\\Comic Battle Royale\\2D Character - Astronaut\\Variant A\\Sprites\\Character\\bomb_hold\\down");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void SetPlayerSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}
