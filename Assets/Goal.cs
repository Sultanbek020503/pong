using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Check if the object colliding is the ball
        {
            gameManager.GoalScored(gameObject.name); // Pass the name of the goal (e.g., "LeftGoal" or "RightGoal")
        }
    }
}
