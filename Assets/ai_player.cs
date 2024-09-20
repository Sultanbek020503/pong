using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;        // Reference to the ball's transform
    public float speed = 10f;     // Speed of the AI paddle
    public float delay = 0.1f;    // Delay time for smoother movement
    public float padding = 0.5f;  // Padding to keep the paddle centered with the ball

    private Rigidbody2D rb;       // Rigidbody2D component of the paddle
    private Vector2 targetPosition; // Target position for the AI paddle

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position; // Initialize target position
    }

    void FixedUpdate()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        // Calculate the target Y position with padding
        float targetY = ball.position.y + padding;

        // Interpolate the target position to create a delay effect
        targetPosition.y = Mathf.Lerp(targetPosition.y, targetY, delay);

        // Move the paddle towards the target position
        Vector2 newPosition = new Vector2(transform.position.x, targetPosition.y);
        rb.MovePosition(Vector2.MoveTowards(transform.position, newPosition, speed * Time.fixedDeltaTime));
    }
}
