using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu2 : MonoBehaviour
{
    public static bool GameISPaused = false;
    public GameObject pauseMenuUI;

    public GameObject PlayerLookScript;

    void Awake()
    {
        PlayerLookScript.GetComponent("MoveCam");//.enabled = true;
    }

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

    void Resume()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;

        GameISPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PlayerLookScript.GetComponent("MoveCam");//.enabled = true;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameISPaused = true;
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        PlayerLookScript.GetComponent("MoveCam");//.enabled = false;
    }
}