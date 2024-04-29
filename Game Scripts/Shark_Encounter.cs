using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Encounter : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource triggerAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            backgroundMusic.volume = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            backgroundMusic.volume = 1f;
        }
    }
}