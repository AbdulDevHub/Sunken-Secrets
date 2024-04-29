using UnityEngine;
using UnityEngine.SceneManagement;

public class EscKey : MonoBehaviour
{
    public string mainMenuSceneName = "Main Menu"; // Name of your Main Menu scene

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}