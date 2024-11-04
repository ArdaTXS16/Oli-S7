using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;    // The player's transform
    public Vector3 offset = new Vector3(0, 3.5f, -7);  // Offset for a realistic 3rd-person view
    public float smoothSpeed = 0.1f; // Smooth movement speed
    public float mouseSensitivity = 10f; // Increased mouse sensitivity
    public float verticalRotationLimit = 80.0f; // Limit the vertical camera angle

    private float currentX = 0.0f;  // Track horizontal mouse movement
    private float currentY = 0.0f;  // Track vertical mouse movement

    void FixedUpdate()
    {
        // Check if the right mouse button is held down
        if (Input.GetButtonDown("Fire1")) // Right mouse button (button index 1)
        {
            // Get mouse input for rotating the camera and scale it by sensitivity
            currentX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Debugging: Log mouse movement and current angles
            Debug.Log($"Mouse X: {Input.GetAxis("Mouse X")} | Mouse Y: {Input.GetAxis("Mouse Y")}");
            Debug.Log($"Current X: {currentX} | Current Y: {currentY}");

            // Clamp the vertical rotation to prevent the camera from flipping over
            currentY = Mathf.Clamp(currentY, -verticalRotationLimit, verticalRotationLimit);
        }

        // Calculate the rotation based on mouse input
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);

        // Set the camera's position with the offset
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smooth the camera movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rotate the camera to always look at the player
        transform.LookAt(target.position);
    }
}
