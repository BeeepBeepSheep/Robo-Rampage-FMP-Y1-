using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu2 : MonoBehaviour
{
    public static bool GameISPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameISPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameISPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("resume");
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameISPaused = true;
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
    }
}