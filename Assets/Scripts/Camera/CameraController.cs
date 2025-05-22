using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 movementCamera;
    [SerializeField] private float sensitivity;

    private void Reset()
    {
        sensitivity = 0.1f;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void MovementCamera(Vector2 value)
    {
        movementCamera += value * sensitivity;
        movementCamera.y = Mathf.Clamp(movementCamera.y, -90f, 90f);
        transform.localRotation = Quaternion.Euler(-movementCamera.y, movementCamera.x, 0);
    }
    private void OnEnable()
    {
        InputReader.movementCamera += MovementCamera;
    }
    private void OnDisable()
    {
        InputReader.movementCamera -= MovementCamera;
    }
}
