using UnityEngine;

public class BallCollisionReset : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        // Store the initial position of the ball
        initialPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with one of the box colliders
        if (collision.collider.CompareTag("Bounds"))
        {
            // Reset the ball's position to the initial position
            ResetBall();
        }
    }

    private void ResetBall()
    {
        // Reset the ball's position and velocity
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
    }
}
