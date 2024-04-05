using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    [SerializeField] public Canvas instructionCanvas;
    [SerializeField] Text instructionText;

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
        instructionText.text = "";
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
            instructionCanvas.gameObject.SetActive(false);
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
            instructionCanvas.gameObject.SetActive(true);
            transform.position = level1Exit;
            SceneManager.LoadScene("Level 1");
        }
        else if (collision.tag == "TeleportLevel2" && GameManager.Instance.keyStatus == 1)
        {
            instructionCanvas.gameObject.SetActive(true);
            transform.position = level2Exit;
            SceneManager.LoadScene("Level 2");
            instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
        }
        else if (collision.tag == "TeleportLevel3" && GameManager.Instance.keyStatus == 2)
        {
            transform.position = level3Exit;
            SceneManager.LoadScene("Level 3");
        }
        else if (collision.CompareTag("TeleportBattle"))
        {
            GameManager.Instance.currentScene = SceneManager.GetActiveScene().name;

            if (collision.gameObject.name == "CitizenAlien1" && !GameManager.Instance.Citizen1Touched)
            {
                GameManager.Instance.alienName = "CitizenAlien1";
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen1Touched = true;
                GameManager.Instance.movementLocked = true;

            }
            if (collision.gameObject.name == "CitizenAlien2" && !GameManager.Instance.Citizen2Touched)
            {
                GameManager.Instance.alienName = "CitizenAlien2";
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen2Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "CitizenAlien3" && !GameManager.Instance.Citizen3Touched)
            {
                GameManager.Instance.alienName = "CitizenAlien3";
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen3Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "CitizenAlien4" && !GameManager.Instance.Citizen4Touched)
            {
                GameManager.Instance.alienName = "CitizenAlien4";
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen4Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "CitizenAlien5" && !GameManager.Instance.Citizen5Touched)
            {
                GameManager.Instance.alienName = "CitizenAlien5";
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen5Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }

            if (collision.gameObject.name == "DoctorAlien1" && !GameManager.Instance.Doctor1Touched)
            {
                GameManager.Instance.alienName = "DoctorAlien1";
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor1Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "DoctorAlien2" && !GameManager.Instance.Doctor2Touched)
            {
                GameManager.Instance.alienName = "DoctorAlien2";
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor2Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "DoctorAlien3" && !GameManager.Instance.Doctor3Touched)
            {
                GameManager.Instance.alienName = "DoctorAlien3";
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor3Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "DoctorAlien4" && !GameManager.Instance.Doctor4Touched)
            {
                GameManager.Instance.alienName = "DoctorAlien4";
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor4Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
            }
            if (collision.gameObject.name == "DoctorAlien5" && !GameManager.Instance.Doctor5Touched)
            {
                GameManager.Instance.alienName = "DoctorAlien5";
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor5Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
            }
            if (collision.gameObject.name == "SuperiorAlien" && !GameManager.Instance.SuperiorTouched)
            {
                GameManager.Instance.alienName = "SuperiorAlien";
                GameManager.Instance.SuperiorTouched = true;
                GameManager.Instance.movementLocked = true;
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Well well. Look who it is..."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Looks like someone has finally awoken from their slumber"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Who are you???"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Who am I? *chuckles* I'm only but the RULER of this planet and this civilization"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "How did I get here?"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "All in due time. But before we keep on chatting let us see if you have been on your best behaviour while occupying in my residence"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Prepare to be JUDGED for your actions!"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Every alien you have encountered is a precious living being that has a job, a family; fears, dreams, ambitions."));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "..."));

                if (GameManager.Instance.aliensKilled == 0)
                {
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "And... you managed to respect each and every alien you encountered and to befriend them."));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "*chuckles*"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "I gotta hand it to you. You have surprised me and earned my respect"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "The reason that you are here is because your rocket ship got caught in our planet's gravity"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "You fell out of the sky and you managed to eject from your ship just in time to save yourself"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "We have encountered humans before, and our experiences have been.... mixed"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Some are outright evil: Killing everything they see in their path"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Some are kind and helpful: Being patient and working through difficulties peacefully "));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Some are kind and helpful: Being patient and working through difficulties peacefully "));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "We are glad you fall into the latter group, but we had our doubts when we discovered your battered body"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "We decided to take a chance on you. The doctors on our planet nursed you and took care of you"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "But we did not expect you to get well so fast. You have been asleep for almost FIVE YEARS"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Your awakening has definitely startled us, but I'm glad no blood has been shed"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Now, it is time to say our fair wells"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "We have a rocket outside that has been reserved to take you off our planet and back home"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Take care human. Stay patient and kind :)"));
                    StartCoroutine(UnlockMovementWhenReady());

                }
                else if (GameManager.Instance.aliensKilled < 3)
                {
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"And... you murdered {GameManager.Instance.aliensKilled} of these precious beings in cold blood..."));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "*chuckles*"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "You want to go home?"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "TELL ME WHY I SHOULD LET YOU LIVE"));
                    StartCoroutine(StartBattleWhenReady());
                }
                else
                {
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", $"And... you MASSACRED {GameManager.Instance.aliensKilled} of MY PRECIOUS PEOPLE..."));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "*chuckles*"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "You want to know why you're here?"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "Well what use will that do?"));
                    ChatManager.Instance.EnqueueDialogue(new ChatMessage("boss", "YOU'RE NOT LEAVING HERE ALIVE!!!"));
                    StartCoroutine(StartBattleWhenReady());
                }
            }
        } else if (collision.CompareTag("Costume")) {
                string name = collision.gameObject.name;
                Debug.Log("hello");
                Animator animator = GetComponent<Animator>();
                RuntimeAnimatorController ac;

                switch (name)
                {
                    case "Blue Costume":
                        ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Blue/BlueController");
                        GameManager.Instance.currentColor = "blue";
                        break;
                    case "Red Costume":
                        ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Red/RedController");
                        GameManager.Instance.currentColor = "red";

                        break;
                    case "Green Costume":
                        ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Green/GreenController");
                        GameManager.Instance.currentColor = "green";

                        break;
                    case "Yellow Costume":
                        ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Yellow/YellowController");
                        GameManager.Instance.currentColor = "yellow";
                        break;
                    case "Pink Costume":
                        ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Pink/PinkController");
                        GameManager.Instance.currentColor = "pink";

                        break;
                    default:
                        ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Blue/BlueController");
                        GameManager.Instance.currentColor = "blue";
                        break;
                }
                animator.runtimeAnimatorController = ac;
        } else if (collision.CompareTag("Chat")) {
                        

            if (collision.gameObject.name == "1stChat" && !GameManager.Instance.triggeredStartDialogue)
            {
                GameManager.Instance.triggeredStartDialogue = true;
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Where am I...???"));
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "I should go look around..."));
                
            } else if (collision.gameObject.name == "Level 2 Door" && GameManager.Instance.keyStatus <1) {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "This door is locked and needs a key"));
            } else if (collision.gameObject.name == "Level 3 Door" && GameManager.Instance.keyStatus < 2) {
                ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "This door is locked and requires a condition to be fulfilled"));
            } 
        } else if (collision.CompareTag("GameEnd")) {
            SceneManager.LoadScene("EndScene"); 
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(2);

        // Code to execute after the wait
        ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "I guess this is it"));
        
        yield return new WaitForSeconds(2);
        if (GameManager.Instance.aliensKilled == 0) {
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "I befriended an alien civilization, by exuding patience, understanding, and respect"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "I did the right thing"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "No..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "You, Player"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Did the right thing"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Keep up the good work chief"));

        } else if (GameManager.Instance.aliensKilled < 3) {
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", $"I've killed {GameManager.Instance.aliensKilled} by mistake, and I've learned nothing about my past"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "I have innocent blood on my hands..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "If I could go back and undo my mistake, I would"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Well, Player"));;
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "What are you waiting for?"));
        } else {
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "I caused chaos in an alien civilization, and learned nothing about my past"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", $"I have the blood of {GameManager.Instance.aliensKilled} innocent creatures on my hands..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Why did I do this...??? *sobs* *sobs*"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "No..."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "You, Player"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", " ... No... You're no player"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "You, MONSTER"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Why did YOU do this?"));
        }
    }

    IEnumerator StartBattleWhenReady()
    {
        // Loop until the condition is met
        yield return new WaitUntil(() => ChatStatus());

        // Code here will execute after the condition is met
        GameManager.Instance.alienToFight = new SuperiorAlienScript();
        SceneManager.LoadScene("BattleScene");
    }

    IEnumerator UnlockMovementWhenReady()
    {
        // Loop until the condition is met
        yield return new WaitUntil(() => ChatStatus());

        // Code here will execute after the condition is met
        GameManager.Instance.movementLocked = false;
    }

    bool ChatStatus()
    {
        // Replace this with your condition
        // For example:
        return !ChatManager.Instance.getIsTyping(); // Wait for 5 seconds
    }
}