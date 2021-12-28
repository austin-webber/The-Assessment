using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using RequireComponent so that I can reuse this script in the future. It makes the script dependent on a component and adds it to the object
[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    // Declaring/initializing variables and creating references
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    // Want to serialize(save) this variable, but don't want it in the inspector, hence [HideInInscpector]
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        // Initializing the character controller component in my script
        characterController = GetComponent<CharacterController>();

        // Lock cursor in the center of the screen and make it inivsible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // To quit the game
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("quit");
            Application.Quit();
        }

        // We are grounded, so recalculate move direction based on axes
        // Essentialy, my new forward is my curent forward
        Vector3 forward = transform.TransformDirection(Vector3.forward); // z-axis
        Vector3 right = transform.TransformDirection(Vector3.right); // x-axis
        
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        // If: canMove >> If: isRunning >> runningSpeed   Else: walkingSpeed
        float currentSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;  // When you press forward or backward, canMove is already true, so if you're running/walking,
        float currentSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0; // multiply runningSpeedwalkingSpeed by your input value (-1 or 1). Same for pressing left or right
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * currentSpeedX) + (right * currentSpeedY); // Calculating our move direction for our controller
        

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded) // Jumping. isGrounded is a function of the characterController component
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY; // AKA: 0
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime); // .Move is a function of the characterController component, requires a Vector3 in motion

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed; // 
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); // setting the max and min limits you can look
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}