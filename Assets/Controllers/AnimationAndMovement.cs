using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Codigo del tutorial https://www.youtube.com/watch?v=bXNFxQpp2qk

public class AnimationAndMovement : MonoBehaviour
{
    Player_input player_input;
    CharacterController characterController;
    Animator animator;

    int isWalkingHash; //Al parecer son más optimos
    int isRunningHash;


    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    float rotationFactorPerFrame = 15.0f;
    float walkVelocityPerFrame = 3.5f;
    float runVelocityPerFrame = 7.0f;

    void Awake()
    {
        player_input = new Player_input();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking"); 
        isRunningHash = Animator.StringToHash("isRunning");


        player_input.ControlesPersonaje.Mover.started += onMomeventInput;
        player_input.ControlesPersonaje.Mover.canceled += onMomeventInput;
        player_input.ControlesPersonaje.Mover.performed += onMomeventInput;

        player_input.ControlesPersonaje.Run.started += onRun;
        player_input.ControlesPersonaje.Run.canceled += onRun;
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton(); //Set the bool
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;


        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation =  Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame*Time.deltaTime); //Interpola en circulo
            
        }

    }

    void onMomeventInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x*walkVelocityPerFrame;
        currentMovement.z = currentMovementInput.y*walkVelocityPerFrame;
        currentRunMovement.x = currentMovementInput.x * runVelocityPerFrame;
        currentRunMovement.z = currentMovementInput.y * runVelocityPerFrame;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

    }

    void handleAnimations()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        //Condiciones del bool para la animación de caminar
        if (isMovementPressed && !isWalking) //Comienza a mover al personaje
        {
            animator.SetBool("isWalking", true);
        }

        else if(!isMovementPressed && isWalking) //Detiene el personaje
        {
            animator.SetBool("isWalking", false);
        }

        //Condiciones para el bool de correr
        if((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if((!isMovementPressed || !isRunPressed) &&isRunning)
        {
            animator.SetBool(isRunningHash, false);

        }


    }

    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -0.05f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.81f;
            currentMovement.y = gravity;
            currentRunMovement.y = gravity;
        }
    }


    // Update is called once per frame
    void Update()
    {
        handleGravity();
        handleRotation();
        handleAnimations();

        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {    
             characterController.Move(currentMovement * Time.deltaTime);
        }

    }

    void OnEnable()
    {
        player_input.ControlesPersonaje.Enable();
    }

    private void OnDisable()
    {
        player_input.ControlesPersonaje.Disable();
    }
}

