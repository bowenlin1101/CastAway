using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{

    private Queue<ChatMessage> dialogQueue = new Queue<ChatMessage>();
    [SerializeField] Image chatImage;
    [SerializeField] Text chatText;
    [SerializeField] Image chatBox;
    private Sprite playerImage;
    [SerializeField] Sprite blueImage;
    [SerializeField] Sprite redImage;
    [SerializeField] Sprite greenImage;
    [SerializeField] Sprite yellowImage;
    [SerializeField] Sprite pinkImage;
    [SerializeField] Sprite citizenAlienImage;
    [SerializeField] Sprite doctorAlienImage;
    [SerializeField] Sprite bossAlienImage;
    public int lettersPerSecond = 24;
    private bool isTyping = false;

    public bool getIsTyping()
    {
        return isTyping;
    }

    public static ChatManager Instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void EnqueueDialogue(ChatMessage message)
    {
        dialogQueue.Enqueue(message);
        if (!isTyping)
        {
            StartCoroutine(ProcessDialogQueue());
        }
    }
    private IEnumerator ProcessDialogQueue()
    {
        Instance.SetActive(true);
        isTyping = true;
        while (dialogQueue.Count > 0)
        {
            ChatMessage chatMessage = dialogQueue.Dequeue();
            Instance.SetImage(chatMessage.Image);
            yield return StartCoroutine(TypeDialog(chatMessage.Message));
            // Optionally wait between dialogues
            yield return new WaitForSeconds(2);
        }
        // Trigger something after all dialogues are processed, if necessary
        Instance.SetActive(false);
        isTyping = false;
    }

    public void SetCanvasCamera(Camera newCamera)
    {
        Canvas canvas = GetComponentInChildren<Canvas>(); // Assuming the Canvas is a child of the GameObject this script is attached to
        if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            canvas.worldCamera = newCamera;
        }
    }

    public void SetImage(string imageName) {
        if (imageName == "citizen") {
            chatImage.sprite = citizenAlienImage;
        } else if (imageName == "doctor") {
            chatImage.sprite = doctorAlienImage;

        } else if (imageName == "boss") {
                    chatImage.sprite = bossAlienImage;
        } else {
            string currentColor = GameManager.Instance.currentColor;

            switch (currentColor) {
                case "blue":
                    playerImage = blueImage;
                    break;
                case "red":
                    playerImage = redImage;
                    break;
                case "green":
                    playerImage = greenImage;
                    break;
                case "yellow":
                    playerImage = yellowImage;
                    break;
                case "pink":
                    playerImage = pinkImage;
                    break;
                default:
                    playerImage = blueImage;
                    break;
            }

            chatImage.sprite = playerImage;
        }
    }

    public IEnumerator TypeDialog(string dialog) {
        chatText.text = "";
        foreach (var letter in dialog.ToCharArray()){
            chatText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
    }

    public void SetActive(bool enable) {
        chatBox.gameObject.SetActive(enable);
    }

    public void Start() {
        Instance.SetActive(false);
    }
}
