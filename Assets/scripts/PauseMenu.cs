using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public player player;
    public BedPlayer bedPlayer;
    public GameObject Fade;
    public static bool JustResumed = false;

    private AudioSource[] allAudioSources;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIManager.IsUIOpen)
            {
                return;
            }
            else
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        if (GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;

        if (player != null && player.isActiveAndEnabled)
        {
            player.canMove = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ResumeAllAudio();
        JustResumed = true;
        StartCoroutine(ResetJustResumed());
    }

    IEnumerator ResetJustResumed()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        JustResumed = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;

        if (player != null && player.isActiveAndEnabled)
        {
            player.canMove = false;
        }

        PauseAllAudio();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Fade.SetActive(true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void PauseAllAudio()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudioSources)
        {
            if (audio.isPlaying)
            {
                audio.Pause();
            }
        }
    }

    void ResumeAllAudio()
    {
        if (allAudioSources == null) return;

        foreach (AudioSource audio in allAudioSources)
        {
            if (!audio.isPlaying)
            {
                audio.UnPause();
            }
        }
    }
}
