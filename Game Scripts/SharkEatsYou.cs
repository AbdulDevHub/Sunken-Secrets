using UnityEngine;
using UnityEngine.SceneManagement;

public class SharkEatsYou : MonoBehaviour
{
    public string gameFailureSceneName = "Game Failure"; // Name of your Game Failure scene

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shark"))
        {
            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(gameFailureSceneName);
        }
    }
}
