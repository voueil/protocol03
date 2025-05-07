using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Camera playerCam;
    public float walkingspeed = 3f;
    public float runningspeed = 6f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookingSpeed = 2f;
    public float lookLimit = 45f;

    Vector3 moveDir = Vector3.zero;
    float rotationX = 0f;

    public bool canMove = true;

    CharacterController characterController;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            return;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningspeed : walkingspeed) * Input.GetAxis("Vertical") : 0f;
        float curSpeedY = canMove ? (isRunning ? runningspeed : walkingspeed) * Input.GetAxis("Horizontal") : 0f;
        float moveDirY = moveDir.y;
        moveDir = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDir.y = jumpPower;
        }
        else
        {
            moveDir.y = moveDirY;
        }

        if (!characterController.isGrounded)
        {
            moveDir.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDir * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookingSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookLimit, lookLimit);
            playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookingSpeed, 0);
        }

    }
}
