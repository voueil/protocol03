using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drower : MonoBehaviour
{
    public GameObject interactYES;
    public bool inReach;
    public bool IsOpen;
    public GameObject Opened;
    public GameObject Closed;
    public BoxCollider thisTriiger;
    public BoxCollider NewTriiger;

    void Start()
    {
        inReach = false;
        IsOpen = false;
        Opened.SetActive(false);
        Closed.SetActive(true);
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
        
    }

    public void DoorOpen()
    {
        thisTriiger.enabled = false;
        NewTriiger.enabled = true;
        Opened.SetActive(true);
        Closed.SetActive(false);
    
    }

   
}
