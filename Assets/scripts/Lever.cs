using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject interactYES;
    public AudioSource OpenFX;
    public AudioSource CloseFX;
    public bool inReach;
    public bool IsOpen;
    public GameObject Opened;
    public GameObject Closed;

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
        else if(inReach && Input.GetButtonDown("Interact") && IsOpen)
        {
            DoorClose();
        }
    }

    public void DoorOpen()
    {
        OpenFX.Play();
        
        Opened.SetActive(true);
        Closed.SetActive(false);
        StartCoroutine(wait1());
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.28f);
        IsOpen = true;
    }

    public void DoorClose()
    {
        CloseFX.Play();
        
        Opened.SetActive(false);
        Closed.SetActive(true);
        StartCoroutine(wait2());
        
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(0.28f);
        IsOpen = false;
    }
}
