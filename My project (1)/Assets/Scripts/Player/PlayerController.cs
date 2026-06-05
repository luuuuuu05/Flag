using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float lookSensitivity = 2f;
    [SerializeField] private Camera playerCamera;

    [SerializeField] private MonoBehaviour playerInputSource;
    private IPlayerInput playerInput;

    private float xRotation;

    private void Awake()
    {
        if (playerInputSource != null)
            playerInput = playerInputSource as IPlayerInput;
    }

    private void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 move;
        Vector2 look;

        if (playerInput != null)
        {
            move = playerInput.Move;
            look = playerInput.Look;
        }
        else
        {
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        HandleMovement(move);
        HandleLook(look);
    }

    private void HandleMovement(Vector2 moveInput)
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void HandleLook(Vector2 lookInput)
    {
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
