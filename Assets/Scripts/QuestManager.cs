using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager _instance;
    public bool keyQuestReq = false;
    public bool keyQuest = false;
    public bool cardQuestReq = false;
    public bool cardQuest = false;
    public bool libroQuestReq = false;
    public bool libroQuest = false;
    public bool penQuestReq = false;
    public bool penQuest = false;
    public bool penSuccess = false;
    public PanelScript ps;

    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<QuestManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("QuestManager");
                    _instance = container.AddComponent<QuestManager>();
                }
            }
            return _instance;
        }
    }

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

    public void Interact(string tag)
    {
        switch (tag)
        {
            case "Key":
                InteractKey();
                break;
            case "Card":
                InteractCard();
                break;
            case "Libro":
                InteractLibro();
                break;
            case "Pen":
                InteractPen();
                break;
            default:
                Debug.Log("Unknown tag: " + tag);
                break;
        }
    }

    private void InteractKey()
    {
        Debug.Log("Interacting with Key");
        if (keyQuestReq)
        {

            keyQuest = true;

        }
        // Key interaction logic here   
    }

    private void InteractCard()
    {
        Debug.Log("Interacting with Card");
        if (cardQuestReq)
        {

            cardQuest = true;

        }
        // Card interaction logic here
    }

    private void InteractLibro()
    {
        Debug.Log("Interacting with Libro");
        if (libroQuestReq)
        {

            libroQuest = true;

        }
        // Libro interaction logic here
    }

    private void InteractPen()
    {
        Debug.Log("Interacting with Pen");
        if (penQuestReq)
        {
            Cursor.lockState = CursorLockMode.None;
            ps.gameObject.SetActive(true);

        }
        // Pen interaction logic here
    }
}
