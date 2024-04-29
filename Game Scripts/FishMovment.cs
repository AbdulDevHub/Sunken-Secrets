using System.Collections;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 0.25f;
    public float rotationSpeed = 10f; // Add this line to define rotation speed
    public float x = 0.5f;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(x, 0, x);
    }

    void Update()
    {
        if (movingForward)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Rotate the fish
            transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);

            // Check if the fish has reached the target position
            if (transform.position == targetPosition)
            {
                movingForward = false;
            }
        }
        else
        {
            // Move back to the original position
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);

            // Rotate the fish
            transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);

            // Check if the fish has reached the original position
            if (transform.position == originalPosition)
            {
                movingForward = true;
            }
        }
    }
}