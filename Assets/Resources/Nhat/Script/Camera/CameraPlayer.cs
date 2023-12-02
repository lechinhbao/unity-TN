using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (your player)
    public float smoothSpeed = 0.125f; // The smoothness of camera movement
    public Vector3 offset; // Offset from the player's position

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not assigned for the camera follow script.");
            return;
        }

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Use SmoothDamp to smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
