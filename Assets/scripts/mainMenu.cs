using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject CreditsMenu;
    public GameObject Fade;

    [Header ("Easter Egg")]
    public AudioSource easterEggAudio;
    private KeyCode[] EasterEgg = new KeyCode[]
  {
        KeyCode.U, KeyCode.U,
        KeyCode.D, KeyCode.D,
        KeyCode.L, KeyCode.R,
        KeyCode.L, KeyCode.R,
        KeyCode.B, KeyCode.A,
        KeyCode.S
  };

    private int codeIndex = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        CheckEasterEgg();
    }

    public void StartGame()
    {
        Fade.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void SettingsEnter()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void CreditsEnter()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainEnter()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void CheckEasterEgg()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(EasterEgg[codeIndex]))
            {
                codeIndex++;
                if (codeIndex >= EasterEgg.Length)
                {
                    TriggerEasterEgg();
                    codeIndex = 0;
                }
            }
            else
            {
                codeIndex = 0;
            }
        }
    }

    void TriggerEasterEgg()
    {
        if (easterEggAudio != null)
            easterEggAudio.Play();

    }
}
