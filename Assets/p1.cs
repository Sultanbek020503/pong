using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1 : MonoBehaviour
{
    public float speed = 10.0f;
    public float boundary = 4.5f; // Limit paddle movement

    void Update()
    {
        float movement = 0;

        // Check input for W and S keys
        if (Input.GetKey(KeyCode.W))
        {
            movement = speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = -speed * Time.deltaTime;
        }

        // Paddle movement within boundaries
        float newYPosition = Mathf.Clamp(transform.position.y + movement, -boundary, boundary);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
