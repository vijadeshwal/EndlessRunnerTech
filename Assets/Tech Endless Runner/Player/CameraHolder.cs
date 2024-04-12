using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Speed of camera movement
    public Vector3 offset; // Offset of the camera from the player

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // Calculate desired position
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly interpolate towards the desired position
            //transform.position = smoothedPosition; // Update camera position
        }
    }

    /*[SerializeField] private Transform playerTransform;
    private Vector3 offset;

    private void Start()
    {
        // Calculate the initial offset as the difference between player and camera positions
        if (playerTransform != null)
        {
            offset = transform.position - playerTransform.position;
        }
    }

    private void Update()
    {
        // Ensure that the playerTransform is not null before trying to follow
        if (playerTransform != null)
        {
            // Calculate the target position based on the initial offset
            Vector3 targetPosition = playerTransform.position + offset;


            // Use Lerp to smoothly interpolate between the current position and the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }
    }*/
}