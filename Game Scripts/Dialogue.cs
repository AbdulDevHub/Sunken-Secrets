using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public AudioSource audioSource;
    public AudioClip dialogueAudio;
    public AudioClip endDialogueAudio;

    private int index;
    private bool isComplete = false;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isComplete)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                isComplete = true;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        audioSource.loop = true; // Ensure the dialogue audio loops
        audioSource.clip = dialogueAudio;
        audioSource.Play();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isComplete = false;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isComplete = true;
    }

    IEnumerator DeactivateAfterAudio()
    {
        yield return new WaitForSeconds(endDialogueAudio.length);
        gameObject.SetActive(false);
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            audioSource.loop = false; // Ensure the end dialogue audio doesn't loop
            audioSource.Stop(); // Stop the dialogueAudio clip
            audioSource.clip = endDialogueAudio; // Set the clip to endDialogueAudio
            audioSource.Play(); // Play the endDialogueAudio clip
            StartCoroutine(DeactivateAfterAudio());
        }
    }
}
