using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayableCharacter : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public bool isCrouching = false;
    public bool isCrawling = false;
    public float crouchHeight = 0.5f;
    public float crawlHeight = 1f;

    private float playerHeight;
    private Vector3 originalCenter;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerHeight = characterController.height;
        originalCenter = characterController.center;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (isCrouching)
        {
            runSpeed = 5f;
            walkSpeed = 4f;
        }
        else if (isCrawling)
        {
            runSpeed = 2f;
            walkSpeed = 2f;
        }
        else
        {
            runSpeed = 6f;
            walkSpeed = 4f;
        }

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && !isCrawling && !isCrouching)
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

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // Toggle between crouch and crawl
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                isCrouching = false;
                characterController.height = playerHeight;
                characterController.center = originalCenter;
            }
            else if (isCrawling)
            {
                isCrawling = false;
                isCrouching = true;
                characterController.height = crouchHeight;
                characterController.center = new Vector3(0, crouchHeight, 0);
            }
            else
            {
                isCrouching = true;
                characterController.height = crouchHeight;
                characterController.center = new Vector3(0, crouchHeight, 0);
            }
        }

        // Check for crawl input
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            if (isCrawling)
            {
                isCrawling = false;
                characterController.height = playerHeight;
                characterController.center = originalCenter;
            }
            else if (isCrouching)
            {
                isCrouching = false;
                isCrawling = true;
                characterController.height = crawlHeight;
                characterController.center = new Vector3(0, crawlHeight, 0); // Adjust the center

            }
            else
            {
                isCrawling = true;
                characterController.height = crawlHeight;
                characterController.center = new Vector3(0, crawlHeight, 0); // Adjust the center
            }
        }
    }
}