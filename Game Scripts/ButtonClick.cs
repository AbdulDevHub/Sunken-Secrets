using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    public AudioSource buttonClickAudioSource; // Assign this in the inspector

    void Start()
    {
        // Get all the Button components in children of the canvas
        Button[] buttons = GetComponentsInChildren<Button>();

        // Add a listener to each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(delegate { OnButtonClick(button); });
        }
    }

    void OnButtonClick(Button button)
    {
        // Execute your commands here
        Debug.Log(button.name + " was clicked!");

        // Play the audio
        if (buttonClickAudioSource != null && !buttonClickAudioSource.isPlaying)
        {
            buttonClickAudioSource.Play();
        }
    }
}