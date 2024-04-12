using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to set the movement speed
    public float minX = -2f; // Minimum X position
    public float maxX = 2f; // Maximum X position

    private Vector3 touchStartPos;
    private bool isDragging = false;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse click or touch on screen
        {
            touchStartPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0)) // Check for mouse release or touch release
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentTouchPos = Input.mousePosition;
            Vector3 direction = (currentTouchPos - touchStartPos).normalized;

            MoveCharacter(direction);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        // Calculate the desired movement
        Vector3 movement = new Vector3(direction.x, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Calculate the new position after movement
        Vector3 newPosition = transform.position + movement;

        // Clamp the X position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply the clamped position
        transform.position = newPosition;
    }
}
