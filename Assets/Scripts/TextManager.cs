using System.Collections;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public CarShake car;
    private static TextManager _instance;
    public static TextManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TextManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("TextManager");
                    _instance = container.AddComponent<TextManager>();
                }
            }
            return _instance;
        }
    }

    [SerializeField] private TMP_Text textDisplay;
    private int currentTextIndex = 0;

    private string[] texts = new string[]
    {
        "Yasin: “Stay calm and let me do the talking. Remember, we're on a casual trip to Egypt.”",
        "Yasin: “Hand me the car keys and let’s get going.”",
        "Yasin: “There’s a checkpoint ahead. Read your passport and remember your identity well. You need to be prepared for any questions they might ask.”",
        "Yasin: \"We're approaching the checkpoint. Stay calm.\"",
        "IDF: \"Stop the car. Let me see your passport.\"",
        "IDF: \"What's the purpose of your trip?\"",
        "Yasin: \"We're just visiting family in Cairo.\"",
        "IDF: \"I'll need to see your license as well.\"",
        "Yasin: \"Let me see… sir, I think I misplaced it. Maybe I left it in the backseat.\"",
        "IDF: \"Hurry up, I'm waiting.\"",
        "\nYasin: “Here it is, officer.”",
        "IDF: “Hm… Alright, give me a second, I’ll be back.”",
        "Yasin: “Psst! Grab the pen in the back seat. Change any faulty information in the passport before he comes back.”",
        "IDF: “Roll down your window.”",
        "IDF: “Let me see your passport as well.”",
        "IDF: “Alright, looks good. You guys can go.”",
        "IDF: “This passport is a fake. You'll need to step out of the car right now.” YOU LOSE",
        "Yasin: “We made it. Welcome to the other side."
    };

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (textDisplay == null)
        {
            Debug.LogError("TextDisplay is not assigned in the TextManager.");
            return;
        }

        DisplayCurrentText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShowNextText();
        }
    }

    private void DisplayCurrentText()
    {
        if (currentTextIndex < texts.Length)
        {
            textDisplay.text = texts[currentTextIndex];
        }
    }

    private void ShowNextText()
    {
        if (currentTextIndex == 1)
        {
            // Check if keyQuest is true in QuestManager
            QuestManager.Instance.keyQuestReq = true;
            if (QuestManager.Instance.keyQuest)
            {
                car.isDriving = true;
                currentTextIndex++;
                DisplayCurrentText();
            }
            else
            {
                Debug.Log("keyQuest is not true yet. Cannot proceed to the next text.");
            }
        }
        else if (currentTextIndex == 4)
        {
            car.isDriving = false;
            currentTextIndex++;
            DisplayCurrentText();
        }
        else if (currentTextIndex == 8)
        {
            // Check if keyQuest is true in QuestManager
            QuestManager.Instance.cardQuestReq = true;
            if (QuestManager.Instance.cardQuest)
            {
                currentTextIndex++;
                DisplayCurrentText();
            }
        }
        else if (currentTextIndex == 12)
        {
            // Check if keyQuest is true in QuestManager
            QuestManager.Instance.penQuestReq = true;
            if (QuestManager.Instance.penQuest)
            {
                currentTextIndex++;
                DisplayCurrentText();
            }
        }
        else if (currentTextIndex == 13)
        {
            // Check if keyQuest is true in QuestManager
            QuestManager.Instance.windowQuestReq = true;
            if (QuestManager.Instance.windowQuest)
            {
                currentTextIndex++;
                DisplayCurrentText();
            }
        }
        else if (currentTextIndex == 14)
        {
            // Check if keyQuest is true in QuestManager
            QuestManager.Instance.libroQuestReq = true;
            if (QuestManager.Instance.libroQuest)
            {
                currentTextIndex++;
                if (QuestManager.Instance.penSuccess == false)
                    currentTextIndex++;
                DisplayCurrentText();
            }
        }
        else if (currentTextIndex == 15)
        {
            car.isDriving = true;
            currentTextIndex++;
            currentTextIndex++;
            DisplayCurrentText();
        }
        else if (currentTextIndex == 16)
        {
            return;
        }
        else if (currentTextIndex < texts.Length - 1)
        {
            currentTextIndex++;
            DisplayCurrentText();
        }
        else
        {
            Debug.Log("No more texts to display.");
        }
    }
}
