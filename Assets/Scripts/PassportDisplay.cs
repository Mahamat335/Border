using UnityEngine;
using UnityEngine.UI;

public class PassportDisplay : MonoBehaviour
{
    public static PassportDisplay Instance { get; private set; }

    public Image passportImage; // Reference to the UI Image component
    public Sprite[] passportPages; // Array of passport page sprites

    private int currentPage = 0;

    private void Awake()
    {
        // Singleton örneğini oluştur
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ensure the passport image is initially hidden
        passportImage.gameObject.SetActive(false);
    }

    void Update()
    {

        if (passportImage.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Input.mousePosition;

                if (mousePosition.x > Screen.width / 2)
                {
                    // Clicked on the right side of the screen
                    NextPage();
                }
                else
                {
                    // Clicked on the left side of the screen
                    PreviousPage();
                }
            }
        }
    }

    public void ShowPassport()
    {
        if (gameObject.activeSelf)
        {
            Debug.Log(1);
            currentPage = 0;
            passportImage.sprite = passportPages[currentPage];
            passportImage.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Debug.Log(12);
            HidePassport();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void NextPage()
    {
        if (currentPage < passportPages.Length - 1)
        {
            currentPage++;
            passportImage.sprite = passportPages[currentPage];
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            passportImage.sprite = passportPages[currentPage];
        }
    }

    public void HidePassport()
    {
        passportImage.gameObject.SetActive(false);
    }
}
