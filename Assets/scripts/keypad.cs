using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class keypad : MonoBehaviour
{
    [SerializeField] private TMP_Text answer;
    public GameObject ClosedGate;
    public GameObject OpenedGate;
    public GameObject NEW_correct;
    public GameObject OLD_wrong;
    public GameObject thiss;
    public player player;

    public string Answer = "4439";

    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public void Number(int number)
    {
        if (clickSound != null && audioSource != null)
            audioSource.PlayOneShot(clickSound);

        answer.text += number.ToString();
    }

    public void Enter()
    {
        if(answer.text == Answer)
        {
            if (correctSound != null && audioSource != null)
                audioSource.PlayOneShot(correctSound);

            thiss.SetActive(false);
            NEW_correct.SetActive(true);
            OLD_wrong.SetActive(false);

            player.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            ClosedGate.SetActive(false);
            OpenedGate.SetActive(true);
        }
        else
        {
            if (wrongSound != null && audioSource != null)
                audioSource.PlayOneShot(wrongSound);

            NEW_correct.SetActive(false);
            OLD_wrong.SetActive(true);

            answer.text = "WRONG";
            StartCoroutine(Wait());
        }


       
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        answer.text = "";
    }


    void Update()
    {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (UIManager.IsUIOpen)
                {
                    thiss.SetActive(false);
                    player.canMove = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    UIManager.IsUIOpen = false;
                }
            }

            if (answer.text.Length > 6)
            {
                if (wrongSound != null && audioSource != null)
                    audioSource.PlayOneShot(wrongSound);

                NEW_correct.SetActive(false);
                OLD_wrong.SetActive(true);

                answer.text = "WRONG";
                StartCoroutine(Wait());
            }
        }

    }
