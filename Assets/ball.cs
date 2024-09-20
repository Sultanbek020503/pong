using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialSpeed = 10.0f; // Speed of the ball
    private Rigidbody2D rb;            // Rigidbody2D component of the ball
    private AudioSource audioSource;   // AudioSource component for playing sound
    public AudioClip hitSound;         // Audio clip to assign from the inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        LaunchBall();
    }

    // Launch the ball in a random direction
    public void LaunchBall()
    {
        float randomDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(randomDirection, Random.Range(-1f, 1f)).normalized * initialSpeed;
    }

    // Detect any collision and play sound
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound(); // Play sound on any collision
    }

    // Function to play the sound
    void PlaySound()
    {
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound); // Plays the hit sound when colliding
        }
    }

    // Reset the ball to the center
    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        Invoke("LaunchBall", 1.0f);
    }

    // Stop the ball when the game ends
    public void StopBall()
    {
        rb.velocity = Vector2.zero; // Stop the ball's movement
    }
}
