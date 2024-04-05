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

    public float interactionSphere = 3f;

    private Vector2 level1Entry = new Vector2(-8.35f, 0.62f);
    private Vector2 level1Exit = new Vector2(11.57f, -5.95f);
    private Vector2 level2Entry = new Vector2(0.04f, 9.09f);
    private Vector2 level2Exit = new Vector2(-27.71f, -25.54f);
    private Vector2 level3Entry = new Vector2(8.19f, 0.59f);
    private Vector2 level3Exit = new Vector2(-3.08f, -9.06f);

    Vector2 movement;

    public static PlayerMovement instance;

    public Interactable focus;

    void Awake()
    {
        instructionText.text = "";
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("InventoryWindow");
            SceneManager.LoadScene("InventoryWindow", LoadSceneMode.Additive);
        }
     

        // interacting with objects

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(rb.position, interactionSphere);
        foreach (var hitCollider in hitColliders)
        {
            Interactable interactable = hitCollider.GetComponent<Interactable>();
            if (interactable != null)
            {
                SetFocus(interactable);
                return; // Exit the loop once an interactable object is focused.
            }
        }

        // If no interactable objects are found, remove focus.
        RemoveFocus();
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
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen1Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
                GameManager.Instance.gotKeyFromAliens();
                instructionText.text = $"{GameManager.Instance.aliensInteracted} Out of 7";
            }
            if (collision.gameObject.name == "CitizenAlien2" && !GameManager.Instance.Citizen2Touched)
            {
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
                GameManager.Instance.alienToFight = new CitizenAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Citizen5Touched = true;
                GameManager.Instance.movementLocked = true;
            }

            if (collision.gameObject.name == "DoctorAlien1" && !GameManager.Instance.Doctor1Touched)
            {
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
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor4Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
            }
            if (collision.gameObject.name == "DoctorAlien5" && !GameManager.Instance.Doctor5Touched)
            {
                GameManager.Instance.alienToFight = new DoctorAlienScript();
                SceneManager.LoadScene("BattleScene");
                GameManager.Instance.Doctor5Touched = true;
                GameManager.Instance.movementLocked = true;
                GameManager.Instance.aliensInteracted++;
            }
            if (collision.gameObject.name == "SuperiorAlien" && !GameManager.Instance.SuperiorTouched)
            {
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
        } 
        else if (collision.CompareTag("Costume"))
        {
            string name = collision.gameObject.name;
            Debug.Log("hello");
            Animator animator = GetComponent<Animator>();
            RuntimeAnimatorController ac;

            switch (name)
            {
                case "Blue Costume":
                    ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Blue/BlueController");
                    break;
                case "Red Costume":
                    Debug.Log("Hello");
                    ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Red/RedController");
                    break;
                case "Green Costume":
                    ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Green/GreenController");
                    break;
                case "Yellow Costume":
                    ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Yellow/YellowController");
                    break;
                case "Pink Costume":
                    ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Pink/PinkController");
                    break;
                default:
                    ac = Resources.Load<RuntimeAnimatorController>("PlayerAnimations/Blue/BlueController");
                    break;
            }
            animator.runtimeAnimatorController = ac;
        }

        if (collision.gameObject.name == "1stChat")
        {
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Where am I...???"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "You're the the hospital obviously"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "But what happened? Why am I here?"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("doctor", "Keep playing to find out ;)"));
        }
        else if (collision.gameObject.name == "2ndChat")
        {
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "Where am I...???"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "What the heck do you mean??? You're in my home you idiot. Stop playing dumb. I'll end you home boy"));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("player", "lmao my bad dude."));
            ChatManager.Instance.EnqueueDialogue(new ChatMessage("citizen", "fuck you"));
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

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != null)
        {
            if (focus != null)
                focus.onDeFocused(null);

            focus = newFocus;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.onDeFocused(null);
        }

        focus = null;
    }
}

