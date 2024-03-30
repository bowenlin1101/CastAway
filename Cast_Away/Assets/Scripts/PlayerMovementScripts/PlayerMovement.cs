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

    [SerializeField]
    private GameObject player;

    private Vector2 level1Entry = new Vector2(-8.35f,0.62f);
    private Vector2 level1Exit = new Vector2(11.57f, -5.95f);
    private Vector2 level2Entry = new Vector2(0.04f, 9.09f);
    private Vector2 level2Exit = new Vector2(-27.71f, -25.54f);
    private Vector2 level3Entry = new Vector2(8.19f, 0.59f);
    private Vector2 level3Exit = new Vector2(-3.08f, -9.06f);

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

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TeleportSpawn")
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                transform.position = level1Entry;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                transform.position = level2Entry;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                transform.position = level3Entry;
            }
            SceneManager.LoadScene("Spawn");
            while (true)
            {
                Debug.Log(transform.position);
                yield return new WaitForSeconds(2f);
            }
        }
        else if (collision.tag == "TeleportLevel1")
        {
            transform.position = level1Exit;
            SceneManager.LoadScene("Level 1");
        }
        else if (collision.tag == "TeleportLevel2")
        {
            transform.position = level2Exit;
            SceneManager.LoadScene("Level 2");
        }
        else if (collision.tag == "TeleportLevel3")
        {
            transform.position = level3Exit;
            SceneManager.LoadScene("Level 3");
        }
        else if (collision.tag == "TeleportBattle")
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
