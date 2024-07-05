using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    [SerializeField] private GameObject passportPanel;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;
    [SerializeField] private Button confirmButton;

    private int selectedValue = -1;

    void Start()
    {
        if (passportPanel == null)
        {
            Debug.LogError("Passport Panel is not assigned.");
            return;
        }

        if (button1 != null)
            button1.onClick.AddListener(() => SetValue(0));
        else
            Debug.LogError("Button 1 is not assigned.");

        if (button2 != null)
            button2.onClick.AddListener(() => SetValue(1));
        else
            Debug.LogError("Button 2 is not assigned.");

        if (button3 != null)
            button3.onClick.AddListener(() => SetValue(2));
        else
            Debug.LogError("Button 3 is not assigned.");

        if (button4 != null)
            button4.onClick.AddListener(() => SetValue(3));
        else
            Debug.LogError("Button 4 is not assigned.");

        if (confirmButton != null)
            confirmButton.onClick.AddListener(HidePanel);
        else
            Debug.LogError("Confirm Button is not assigned.");
    }

    private void SetValue(int value)
    {
        selectedValue = value;
        Debug.Log("Selected Value: " + selectedValue);
    }

    private void HidePanel()
    {
        passportPanel.SetActive(false);
        Debug.Log("Passport Panel hidden.");
        QuestManager.Instance.penQuest = true;
        if (selectedValue == 0)
            QuestManager.Instance.penSuccess = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
