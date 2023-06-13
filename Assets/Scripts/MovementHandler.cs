using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float releaseHeight = 5f;
    [SerializeField] private float bounceDamping = 0.8f;

    private bool isClicked = false;
    private Vector3 mouseStartPosition;
    private Rigidbody rb;

    private bool hasBounced = false;
    private float currentReleaseHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 1f; // Add drag to simulate air resistance

        // Add a physics material with bounce properties to the ball's collider
        Collider collider = GetComponent<Collider>();
        collider.material = new PhysicMaterial()
        {
            bounciness = 0.5f, // Adjust the bounciness factor as desired
            dynamicFriction = 0.5f,
            staticFriction = 0.5f
        };
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    isClicked = true;
                    mouseStartPosition = Input.mousePosition;
                    rb.isKinematic = true; // Disable physics while dragging
                    rb.velocity = Vector3.zero; // Reset the ball's velocity
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isClicked)
            {
                Vector3 mouseEndPosition = Input.mousePosition;
                Vector3 mouseDelta = mouseEndPosition - mouseStartPosition;
                rb.isKinematic = false; // Enable physics after releasing

                // Calculate the movement vector based on mouse movement
                Vector3 movement = new Vector3(mouseDelta.x, 0, mouseDelta.y);
                movement *= movementSpeed * Time.deltaTime;

                // Apply the movement to the ball's position
                rb.AddForce(movement, ForceMode.VelocityChange);

                // Apply an upward force to give the ball height
                if (!hasBounced)
                {
                    currentReleaseHeight = releaseHeight;
                    rb.AddForce(Vector3.up * currentReleaseHeight, ForceMode.VelocityChange);
                    hasBounced = true;
                }
                else
                {
                    currentReleaseHeight *= bounceDamping;
                    rb.AddForce(Vector3.up * currentReleaseHeight, ForceMode.VelocityChange);
                }

                isClicked = false;
            }
        }
    }
}
