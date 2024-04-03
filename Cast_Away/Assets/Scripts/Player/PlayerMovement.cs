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

    private Vector2 level1Entry = new Vector2(-8.35f, 0.62f);
    private Vector2 level1Exit = new Vector2(11.57f, -5.95f);
    private Vector2 level2Entry = new Vector2(0.04f, 9.09f);
    private Vector2 level2Exit = new Vector2(-27.71f, -25.54f);
    private Vector2 level3Entry = new Vector2(8.19f, 0.59f);
    private Vector2 level3Exit = new Vector2(-3.08f, -9.06f);

    Vector2 movement;

    public static PlayerMovement instance;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

    void Update()
    {
        if (!GameManager.Instance.movementLocked)
        {
            Debug.Log("Moving");
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movement.x < 0)
            {
                spriteRenderer.flipX = false;
            }

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        DontDestroyOnLoad(this);
    }

    public void SetPlayerSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
        }
        else if (collision.tag == "TeleportLevel1")
        {
            transform.position = level1Exit;
            SceneManager.LoadScene("Level 1");
        }
        else if (collision.tag == "TeleportLevel2" && GameManager.Instance.keyStatus == 1)
        {
            transform.position = level2Exit;
            SceneManager.LoadScene("Level 2");
        }
        else if (collision.tag == "TeleportLevel3" && GameManager.Instance.keyStatus == 2)
        {
            transform.position = level3Exit;
            SceneManager.LoadScene("Level 3");
        }
        else if (collision.tag == "TeleportBattle")
        {

            if (collision.gameObject.name == "CitizenAlien1" && !GameManager.Instance.Citizen1Touched) {
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen1Touched = true;
                GameManager.Instance.movementLocked = true;
            } else if (collision.gameObject.name == "DoctorAlien1" && !GameManager.Instance.Doctor1Touched) {
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor1Touched = true;
                GameManager.Instance.movementLocked = true; 
            }
        }

        if (collision.gameObject.name == "1stChat") {
            Debug.Log("start");
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Where am I...???"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "You're the the hospital obviously"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "But what happened? Why am I here?"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "Keep playing to find out ;)"));
        } else if (collision.gameObject.name == "2ndChat") {
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Where am I...???"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "What the heck do you mean??? You're in my home you idiot. Stop playing dumb. I'll end you home boy"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "lmao my bad dude."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "fuck you"));
        }
    }
}