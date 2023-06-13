using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    private int score = 0;
    private bool ballInsideGoal = false;
    private float resetDelay = 2f; // Delay in seconds before resetting the ball
    public ScoreCounter scoreCounter;
    private Rigidbody ballRb;
    private AudioSource audioSource;

    public AudioClip goalScoreAudio;

    private void Start()
    {
        ballRb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Set the ballInsideGoal flag to true
            ballInsideGoal = true;

            // Increment the score
            scoreCounter.IncrementScore();
            score++;

            // Reset the ball
            ResetBall();
            Debug.Log("Score: " + score);

            // Play the goal score audio clip
            audioSource.PlayOneShot(goalScoreAudio);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Set the ballInsideGoal flag to false
            ballInsideGoal = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !ballInsideGoal)
        {
            // Reset the ball when right mouse button is clicked
            ResetBall();
        }
    }

    private void ResetBall()
    {
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        ballRb.position = new Vector3(0f, 0.06f, 0f); // Set the ball's initial position
        ballRb.rotation = Quaternion.identity; // Reset the ball's rotation
        ballRb.useGravity = true; // Enable gravity for the ball
    }
}
