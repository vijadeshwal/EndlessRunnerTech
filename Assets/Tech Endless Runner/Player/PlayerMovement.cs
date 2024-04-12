using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float limitX;
    [SerializeField] private float sidewaySpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationLerpSpeed;
    [SerializeField] private float resetRotationDelay;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private Transform playerModel;

    private float _initialMousePositionX;
    private float _finalPos;
    private float _currentPos;
    private Quaternion _targetRotation;
    private Vector3 _previousMousePosition;
    private bool _isMouseIdle;

    public bool isRunning = false;

    private void Update()
    {
        if(isRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _initialMousePositionX = Input.mousePosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                MovePlayer();
            }

            // Continuous forward movement along the z-axis
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

            // Check if the mouse position has not changed for a certain duration
            CheckMouseIdle();
            if (_isMouseIdle)
            {
                // Rotate back to the original position with a delay
                StartCoroutine(ResetRotation());
            }
        }

       
    }

    private void MovePlayer()
    {
        float mouseDeltaX = Input.mousePosition.x - _initialMousePositionX;
        float percentageX = mouseDeltaX / (Screen.width * 0.5f) * 2;
        percentageX = Mathf.Clamp(percentageX, -1.0f, 1.0f);
        _finalPos = percentageX * limitX;

        float delta = _finalPos - _currentPos;
        _currentPos += (delta * Time.deltaTime * sidewaySpeed);
        _currentPos = Mathf.Clamp(_currentPos, -limitX, limitX);

        playerModel.localPosition = new Vector3(_currentPos, 0, 0);

        if(!_isMouseIdle)
        {
            // Calculate target rotation based on drag direction
            float rotationAngle = Mathf.Clamp(percentageX, -1.0f, 1.0f) * rotationSpeed;
            _targetRotation = Quaternion.Euler(-90, rotationAngle, 0);

            // Apply rotation using Lerp for smooth rotation
            playerModel.localRotation = Quaternion.Lerp(playerModel.localRotation, _targetRotation, Time.deltaTime * rotationLerpSpeed);
        }
        
    }

    private void CheckMouseIdle()
    {
        // Check if the current mouse position is the same as the previous position
        if (Input.mousePosition == _previousMousePosition)
        {
            _isMouseIdle = true;
        }
        else
        {
            // Update the previous mouse position
            _previousMousePosition = Input.mousePosition;
            _isMouseIdle = false;
        }
    }

    private System.Collections.IEnumerator ResetRotation()
    {
        // Wait for the specified delay before resetting rotation
        yield return new WaitForSeconds(resetRotationDelay);
        

        // Rotate back to the original position
        _targetRotation = Quaternion.Euler(-90, 0, 0);
        playerModel.localRotation = Quaternion.Lerp(playerModel.localRotation, _targetRotation, Time.deltaTime * rotationLerpSpeed);
    }
}
