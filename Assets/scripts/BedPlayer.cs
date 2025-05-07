using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedPlayer : MonoBehaviour
{
    public Camera playerCam;
    public float lookingSpeed = 2f;
    public float lookLimit = 45f;

    float rotationX = 0f;
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

        rotationX += -Input.GetAxis("Mouse Y") * lookingSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookLimit, lookLimit);
        playerCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookingSpeed, 0);
    }
}
