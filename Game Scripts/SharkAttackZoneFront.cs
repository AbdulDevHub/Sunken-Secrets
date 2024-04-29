using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttackZoneFront : MonoBehaviour
{
    public Transform player;
    public Transform shark;
    public float speed = 2.0f;
    private Vector3 originalPosition;
    private bool returnToOriginalPosition = false;

    void Start()
    {
        originalPosition = shark.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Removed the LookAt function call
        if (other.gameObject.CompareTag("Player"))
        {
            returnToOriginalPosition = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shark.position = Vector3.MoveTowards(shark.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            returnToOriginalPosition = true;
            StartCoroutine(ReturnToOriginalPosition());
        }
    }

    IEnumerator ReturnToOriginalPosition()
    {
        while (returnToOriginalPosition && Vector3.Distance(shark.position, originalPosition) > 0.01f)
        {
            shark.position = Vector3.MoveTowards(shark.position, originalPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}