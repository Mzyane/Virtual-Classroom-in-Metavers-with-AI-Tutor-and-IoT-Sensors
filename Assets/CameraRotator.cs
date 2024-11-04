using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of the rotation

    void Update()
    {
        // Rotate the camera around the Y-axis based on horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
