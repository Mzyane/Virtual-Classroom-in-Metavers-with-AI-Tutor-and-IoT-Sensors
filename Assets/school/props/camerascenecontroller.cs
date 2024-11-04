using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 100.0f;  // Speed of rotation

    private float xRotation = 0.0f; // Rotation around the X-axis
    private float yRotation = 0.0f; // Rotation around the Y-axis

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Update the X and Y rotation angles based on mouse movement
        xRotation -= mouseY; // Invert if necessary
        yRotation += mouseX;

        // Clamp the X rotation to prevent flipping (e.g., between -90 and +90 degrees)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
    }
}
