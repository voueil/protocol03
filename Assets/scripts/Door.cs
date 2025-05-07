using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject interactYES;
    public AudioSource CloseDoorFX;
    public bool inReach;
    public bool IsOpen;
    public GameObject OpenedDoor;
    public GameObject ClosedDoor;

    void Start()
    {
        inReach = false;
        IsOpen = false;
        OpenedDoor.SetActive(false);
        ClosedDoor.SetActive(true);
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
        if(inReach && Input.GetButtonDown("Interact") && !IsOpen)
        {
            DoorOpen();
        }
        else if(inReach && Input.GetButtonDown("Interact") && IsOpen)
        {
            DoorClose();
        }
    }

    public void DoorOpen()
    {
        SceneManager.LoadScene(2);
        
        OpenedDoor.SetActive(true);
        ClosedDoor.SetActive(false);
        IsOpen = false;
    }

    public void DoorClose()
    {
        CloseDoorFX.Play();
        
        OpenedDoor.SetActive(false);
        ClosedDoor.SetActive(true);
        IsOpen = false;
    }
}
