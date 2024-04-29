using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttackZoneBack : MonoBehaviour
{
    public Transform player;
    public Transform shark;
    public float speed = 4.0f;
    private Vector3 originalPosition;
    private bool returnToOriginalPosition = false;

    void Start()
    {
        originalPosition = shark.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            returnToOriginalPosition = false;
            shark.rotation = Quaternion.Euler(0, shark.rotation.eulerAngles.y + 180, 0); // Add 180 degrees to the current rotation
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
            shark.rotation = Quaternion.Euler(0, shark.rotation.eulerAngles.y + 180, 0); // Add 180 degrees to the current rotation
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