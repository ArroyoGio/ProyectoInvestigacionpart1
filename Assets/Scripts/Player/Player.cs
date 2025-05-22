using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Characteristics")]
    [SerializeField] private float speed;

    [Header("Camera")]
    [SerializeField] private Transform cameraPlayer;

    private Vector2 inputPlayer;
    private Vector3 moveDirection;
    private void Reset()
    {
        speed = 5;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveDirection = (cameraPlayer.forward * inputPlayer.y + cameraPlayer.right * inputPlayer.x).normalized;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveDirection.x*speed,rb.linearVelocity.y,moveDirection.z*speed);
    }
    private void OnEnable()
    {
        InputReader.movementPlayer += MovementPlayer;
    }
    private void OnDisable()
    {
        InputReader.movementPlayer -= MovementPlayer;
    }
    private void MovementPlayer(Vector2 value)
    {
        inputPlayer = value;
    }
}
