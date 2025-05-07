using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFinalO : MonoBehaviour
{

    public Lever Lever1;
    public Lever Lever2;
    public Lever Lever3;
    public Lever Lever4;
    public GameObject closedGate;
    public GameObject openedGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Lever1.IsOpen == true && Lever2.IsOpen == true && Lever3.IsOpen == true && Lever4.IsOpen == false)
        {
            closedGate.SetActive(false);
            openedGate.SetActive(true);
        }
    }
}
