using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovment : MonoBehaviour
{
    public List<GameObject> waypoints;
    public List<GameObject> turningWaypoints; // Waypoints that make the shark turn
    public float speed = 2;
    int index = 0;
    public bool isLoop = true;
    public float rotationSpeed = 1f; // Speed of rotation
    public float rotationDegree = 180f; // Rotation degree

    void Start()
    {

    }

    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
                if (turningWaypoints.Contains(waypoints[index])) // If the next waypoint is a turning waypoint
                {
                    StartCoroutine(RotateObject(rotationSpeed, transform, new Vector3(0, rotationDegree, 0), 1f));
                }
            }
            else
            {
                if (isLoop)
                {
                    index = 0;
                }
            }
        }
    }

    IEnumerator RotateObject(float duration, Transform t, Vector3 angles, float delay)
    {
        yield return new WaitForSeconds(delay);

        Quaternion startRotation = t.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            t.rotation = Quaternion.Lerp(startRotation, endRotation, time / duration);
            yield return null;
        }
        t.rotation = endRotation;
    }
}