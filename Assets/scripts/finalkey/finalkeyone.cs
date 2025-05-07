using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class finalkeyone : MonoBehaviour
{
    public GameObject interactYES;
    public AudioSource OpenFX;
   
    public bool inReach;
    public bool IsOpen;
    public GameObject normal;
    public GameObject pressed;
    public TMP_Text counter;
    public int thenumber;


    void Start()
    {
        inReach = false;
        IsOpen = false;
       
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
            thenumber++;


        }

        counter.text = thenumber.ToString();

        if (thenumber > 20)
        {
            thenumber = 0;
        }
            

    }

    public void DoorOpen()
    {
        pressed.SetActive(true);
        normal.SetActive(false);
        OpenFX.Play();
        IsOpen = true;
        StartCoroutine(wait1());
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.1f);
        IsOpen = false;
        pressed.SetActive(false);
        normal.SetActive(true);
    }

   

   
}
