using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDone : MonoBehaviour
{

    public finalkeyone finalkeyone;
    public finalkeyone finalkeyTwo;
    public finalkeyone finalkeythree;
    public finalkeyone finalkeyfour;
    public GameObject oldDoor;
    public GameObject newDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finalkeyone.thenumber == 13 && finalkeyTwo.thenumber == 11 && finalkeythree.thenumber == 16 && finalkeyfour.thenumber == 9)
        {
            oldDoor.SetActive(false);
            newDoor.SetActive(true);
        }
    }
}
