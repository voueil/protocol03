using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeSystem : MonoBehaviour
{

    public GameObject fadeout;
    public GameObject GetUpText;
    public GameObject playerbed;
    public GameObject playerstand;
    public GameObject playerstandSoundEffect;
    public GameObject fadein;
    public player player;
    public bool canGetUp = false;
    // Start is called before the first frame update
    void Start()
    {
        fadeout.SetActive(true);
        StartCoroutine(wait());
        canGetUp = false;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        fadeout.SetActive(false);
        yield return new WaitForSeconds(3);
        GetUpText.SetActive(true);
        canGetUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canGetUp && Input.GetKeyUp(KeyCode.E))
        {
            GetUpText.SetActive(false);
            canGetUp = false;
            StartCoroutine(Wait2());
        }
    }

    IEnumerator Wait2()
    {
        fadein.SetActive(true);
        yield return new WaitForSeconds(1);
        playerstandSoundEffect.SetActive(true);
        yield return new WaitForSeconds(3);
        playerstand.SetActive(true);
        playerbed.SetActive(false);
        player.canMove = false;
        yield return new WaitForSeconds(1);
        fadein.SetActive(false);
        player.canMove = true;
        fadeout.SetActive(true);
        yield return new WaitForSeconds(1);
        fadeout.SetActive(false);
        
        

    }
}
