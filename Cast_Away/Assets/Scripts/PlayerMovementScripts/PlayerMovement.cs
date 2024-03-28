using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer spriteRenderer; 
    public Sprite playerSprite;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0) {
            spriteRenderer.flipX = true;
        } else if (movement.x < 0) {
            spriteRenderer.flipX = false;
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TeleportSpawn")
        {
            SceneManager.LoadScene("Spawn");
        }
        else if (collision.tag == "TeleportLevel1")
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (collision.tag == "TeleportLevel2")
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (collision.tag == "TeleportLevel3")
        {
            SceneManager.LoadScene("Level 3");
        }
        else if (collision.tag == "TeleportBattle")
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
