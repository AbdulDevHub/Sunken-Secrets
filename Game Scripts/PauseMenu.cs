using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    private CanvasGroup canvasGroup;
    private bool isPaused = false;
    public GameObject CharacterController;
    public List<AudioSource> audioSources;
    void Start()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.enabled = false;
            canvasGroup = pauseCanvas.GetComponent<CanvasGroup>();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        if (pauseCanvas != null)
        {
            pauseCanvas.enabled = true;
            CharacterController.SetActive(false);
        }
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.Pause();
            }
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Optional: unlock the cursor
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        if (pauseCanvas != null)
        {
            pauseCanvas.enabled = false;
            CharacterController.SetActive(true);
        }
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.UnPause();
            }
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}