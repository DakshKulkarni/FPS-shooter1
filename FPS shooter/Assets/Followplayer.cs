using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform; 
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0.0065f, 0.0094f, 0.0055f);

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPosition = playerTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(playerTransform.position);
        }
        else
        {
            Debug.LogError("Player transform not assigned to CameraFollow script.");
        }
    }
}
