using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Bu fonksiyon bir sonraki sahneyi yükler
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Sahne indeksinin mevcut sahne sayısını aşmadığından emin olun
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Sonraki sahne mevcut değil. Sahne dizinini kontrol edin.");
        }
    }

    // Bu fonksiyon oyunu kapatır
    public void QuitGame()
    {
        // Unity Editöründeyken çalışmasını sağlar
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
