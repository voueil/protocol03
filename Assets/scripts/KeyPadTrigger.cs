using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadTrigger : MonoBehaviour
{
    public GameObject interactYES;
    public bool inReach;
    public bool IsOpen;

    public GameObject KeyPadUI;
    public player player;

    void Start()
    {
        inReach = false;


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            interactYES.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            interactYES.SetActive(false);
        }
    }


    void Update()
    {
        if (PauseMenu.JustResumed) return;
        if (Time.timeScale == 0f) return;

        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpen();
        }
        
    }

    public void DoorOpen()
    {
        KeyPadUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.canMove = false;
        UIManager.IsUIOpen = true;
    }




}
