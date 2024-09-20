using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2 : MonoBehaviour
{
    public float speed = 10.0f;
    public float boundary = 4.5f; // Limit paddle movement

    void Update()
    {
        float movement = 0;

        // Check input for up and down arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement = speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement = -speed * Time.deltaTime;
        }

        // Paddle movement within boundaries
        float newYPosition = Mathf.Clamp(transform.position.y + movement, -boundary, boundary);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
