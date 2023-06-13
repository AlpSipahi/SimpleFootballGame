using UnityEngine;
using System.Collections;

public class OnTrigger : MonoBehaviour
{
    private int score = 0;
    private bool ballInsideGoal = false;
    private float resetDelay = 2f; // Delay in seconds before resetting the ball

    private Rigidbody ballRb;

    private void Start()
    {
        ballRb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Set the ballInsideGoal flag to true
            ballInsideGoal = true;

            // Increment the score
            score++;

            // Reset the ball
            ResetBall();

            Debug.Log("Score: " + score);

           
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
    }
}
