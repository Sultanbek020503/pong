using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;               // Reference to the BallMovement script
    public Text p1ScoreText;        // UI Text for Player 1's score
    public Text p2ScoreText;        // UI Text for Player 2's score
    public Text gameOverText;       // UI Text for game over/winner message

    private int p1Score = 0;        // Player 1 score counter
    private int p2Score = 0;        // Player 2 score counter

    private int maxScore = 5;       // Maximum score to win the game

    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Hide the game over message at the start
    }

    // Function to update the score when a goal is scored
    public void GoalScored(string goal)
    {
        if (goal == "LeftGoal")
        {
            p2Score++; // Player 2 scores if the ball hits the left goal
            p2ScoreText.text = p2Score.ToString(); // Update Player 2 score text
        }
        else if (goal == "RightGoal")
        {
            p1Score++; // Player 1 scores if the ball hits the right goal
            p1ScoreText.text = p1Score.ToString(); // Update Player 1 score text
        }

        // Check if someone has won
        if (p1Score >= maxScore)
        {
            EndGame("Player 1 Wins!");
        }
        else if (p2Score >= maxScore)
        {
            EndGame("Player 2 Wins!");
        }
        else
        {
            ball.ResetBall(); // Reset the ball if no one has won yet
        }
    }

    // Function to end the game
    void EndGame(string winner)
    {
        ball.StopBall(); // Stop the ball's movement
        gameOverText.text = winner; // Display the winner
        gameOverText.gameObject.SetActive(true); // Show the game over message
    }
}
