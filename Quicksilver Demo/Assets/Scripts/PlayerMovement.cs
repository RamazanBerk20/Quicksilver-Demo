using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public bool isSprinting;
    public float speed;
    public float SprintAmp;
    private float defaultSpeed;

    [Header("Jump")]
    public float jumpHeight;
    private float defaultJumpHeight;

    [Header("Mouse")]
    public float mouseSenitivity;
    private float defaultMouseSenitivity;
    private float xRotation = 0f;
    
    private Vector3 velocity;
    private CharacterController characterController;
    private new Camera camera;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        defaultSpeed = speed;
        defaultJumpHeight = jumpHeight;
        defaultMouseSenitivity = mouseSenitivity;

        camera = Camera.main;
    }

    private void Update()
    {
        Movement();
        Look();
        Sprint();
        Gravity();
        Jump();
    }

    private void Movement()
    {
        // Get the input from the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move the player based on the input
        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.unscaledDeltaTime);
    }

    private void Sprint()
    {
        isSprinting = Input.GetButton("Sprint");

        if (isSprinting)
        {
            speed = defaultSpeed * SprintAmp;
        }
        else
        {
            speed = defaultSpeed;
        }
    }

    private void Look()
    {
        // Mouse X and Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSenitivity * Time.unscaledDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenitivity * Time.unscaledDeltaTime;

        // Rotate the player based on the mouse X
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera based on the mouse Y,
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera
        camera.transform.localRotation = Quaternion.Euler(xRotation, camera.transform.localRotation.y, camera.transform.localRotation.z);
    }

    private void Gravity()
    {
        velocity.y += Physics.gravity.y * Time.unscaledDeltaTime;
        characterController.Move(velocity * Time.unscaledDeltaTime);

        if (characterController.isGrounded)
        {
            velocity.y = -2f;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
    }
}
