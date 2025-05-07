using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSystem : MonoBehaviour
{
    public GameObject interactYES;
    public bool inReach;
    public bool IsOpen;
    public GameObject PaperMenu;
    public player player;


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
        if (PauseMenu.JustResumed) return;
        if (Time.timeScale == 0f) return;
        
        if (inReach && Input.GetButtonDown("Interact") && !IsOpen)
        {
            PickPaper();
        }
        else if (inReach && Input.GetButtonDown("Cancel") && IsOpen)
        {
            DropPaper();
        }
    }

    public void PickPaper()
    {
        PaperMenu.SetActive(true);
        interactYES.SetActive(false);
        IsOpen = true;
        player.canMove = false;
        UIManager.IsUIOpen = true;
    }

    public void DropPaper()
    {
        PaperMenu.SetActive(false);
        interactYES.SetActive(true);
        IsOpen = false;
        player.canMove = true;
        UIManager.IsUIOpen = false;
    }
}
