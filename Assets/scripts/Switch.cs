using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject interactYES;
    public AudioSource OpenFX;
    public AudioSource CloseFX;
    public bool inReach;
    public bool IsOpen;
    public GameObject Opened;
    public GameObject Closed;
    public GameObject Lights;
    public GameObject Hint;

    void Start()
    {
        inReach = false;
        IsOpen = true;
        Opened.SetActive(true);
        Closed.SetActive(false);
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
            SwitchOpen();
        }
        else if(inReach && Input.GetButtonDown("Interact") && IsOpen)
        {
            SwitchClose();
        }
    }

    public void SwitchOpen()
    {
        OpenFX.Play();
        Lights.SetActive(true);
        Hint.SetActive(false);
        Opened.SetActive(true);
        Closed.SetActive(false);
        StartCoroutine(wait1());
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.05f);
        IsOpen = true;
    }

    public void SwitchClose()
    {
        CloseFX.Play();
        Lights.SetActive(false);
        Hint.SetActive(true);
        Opened.SetActive(false);
        Closed.SetActive(true);
        StartCoroutine(wait2());
        
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(0.05f);
        IsOpen = false;
    }
}
