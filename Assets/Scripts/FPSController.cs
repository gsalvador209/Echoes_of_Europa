using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;

    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float jumpPower = 7f;

    public Light flashlight;
    float flashlightTiltSpeed = 2.0f; //Velocidad de inclinación
    float flashlightTiltLimit = 30.0f;

    public bool canMove = true;
    CharacterController characterController;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    float flashlightRotationX = 0;
    float gravity = 9.81f;

    float walkSpeed = 3.5f;
    float runSpeed =  7.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (flashlight != null)
            flashlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Flashlight
        if (flashlight != null)
        {
            // Toggle flashlight on/off with F
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = !flashlight.enabled;
            }

            // Adjust flashlight tilt with mouse
            if (flashlight.enabled)
            {
                flashlightRotationX += -Input.GetAxis("Mouse Y") * flashlightTiltSpeed;
                flashlightRotationX = Mathf.Clamp(flashlightRotationX, -flashlightTiltLimit, flashlightTiltLimit);
                flashlight.transform.localRotation = Quaternion.Euler(flashlightRotationX, 0, 0);
            }
        }
        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion


        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion


        #region Update Animator States
        // Check if there's movement
        bool isMoving = curSpeedX != 0 || curSpeedY != 0;

        animator.SetBool("isWalking", isMoving && !isRunning);
        animator.SetBool("isRunning", isMoving && isRunning);
        #endregion

    }
}
