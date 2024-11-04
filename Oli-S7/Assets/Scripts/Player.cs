using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;         // Speed of the player's movement
    public float jumpForce = 5.0f;         // Force applied when jumping

    public LayerMask groundLayer;          // Layer that represents the ground
    public Transform groundCheck;          // Position to check if player is grounded
    private Rigidbody rb;                  // Rigidbody component
    private bool isGrounded;               // Check if the player is on the ground
    private bool doubleJump = false;       // Track if double jump is allowed
    public float groundCheckRadius = 0.2f; // Radius for ground check

    void Start()
    {
        rb = GetComponent<Rigidbody>();    // Get the Rigidbody component
    }

    void Update()
    {
        // Get input for horizontal and vertical (WASD or Arrow keys)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Log input values (optional)
        Debug.Log("Horizontal: " + horizontal + " Vertical: " + vertical);

        // Move the player using input values, multiplied by moveSpeed and Time.deltaTime
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement); // Use Rigidbody for movement

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log("Is Grounded: " + isGrounded); // Optional log for debugging

        if (isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false; // Reset double jump when player is grounded
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                // First jump
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
            else if (!doubleJump)
            {
                // Double jump
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                doubleJump = true; // Disable further double jumps
            }
        }

        // Optional: Reduce jump height if button is released mid-air
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, rb.velocity.z);
        }
    }
}
