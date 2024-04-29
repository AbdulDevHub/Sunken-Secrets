using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
  public void PlayGame ()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(1);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        StartCoroutine(LoadMainMenuWithDelay());
    }

    IEnumerator LoadMainMenuWithDelay()
    {
        // Play the audio here

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        // Load the main menu
        SceneManager.LoadScene("Main Menu");
    }
}
