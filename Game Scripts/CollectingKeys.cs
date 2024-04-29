using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Add this line

public class CollectingKeys : MonoBehaviour
{
    public AudioSource keyCollectionSound; // Drag your AudioSource here
    public string gameOverSceneName = "Game Victory"; // Name of your Game Over scene
    private int keysCollected = 0;
    public GameObject chestTop; // Drag your ChestV1_Top object here
    public TextMeshProUGUI keyDialogue; // Drag your TextMeshProUGUI object here
    public AudioSource chestOpeningSound; // Drag your AudioSource here

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            keysCollected = 3;
            StartCoroutine(ShowKeyDialogue());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keysCollected++;
            keyCollectionSound.Play();
            StartCoroutine(ShowKeyDialogue());
        }
        else if (other.gameObject.CompareTag("Chest") && keysCollected >= 3)
        {
            StartCoroutine(OpenChestAndLoadScene());
        }
    }

    IEnumerator ShowKeyDialogue()
    {
        if (keysCollected < 3)
        {
            keyDialogue.text = "You Found A Key!\n" + (3 - keysCollected).ToString() + " Key(s) Remain.";
        }
        else
        {
            keyDialogue.text = "You Found The Last Key!\nGo Find The Treasure Chest.";
        }
        keyDialogue.enabled = true;
        yield return new WaitForSeconds(2.5f);
        keyDialogue.enabled = false;
    }

    IEnumerator OpenChestAndLoadScene()
    {
        // Animate the chest opening
        chestTop.transform.localPosition = new Vector3(-0.3715969f, 0.219f, -0.004f);
        chestTop.transform.localRotation = Quaternion.Euler(-90, 0, 0);

        // Play the chest opening sound
        chestOpeningSound.Play();

        // Wait for 2.7 seconds
        yield return new WaitForSeconds(2.7f);

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Load the next scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}