using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject interactYES;
 
    public bool inReach;
    public bool IsOpen;
    public GameObject Pressed;
    public GameObject Normal;
    public float timee;

    void Start()
    {
        inReach = false;
        IsOpen = false;
        Pressed.SetActive(false);
        Normal.SetActive(true);
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
        IsOpen = true;
        Pressed.SetActive(true);
        Normal.SetActive(false);
        StartCoroutine(wait1());
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(timee);
        IsOpen = false;
        Pressed.SetActive(false);
        Normal.SetActive(true);
    }

   
}
