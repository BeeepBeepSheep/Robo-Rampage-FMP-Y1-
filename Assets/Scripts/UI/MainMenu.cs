using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void LoadMedium()
    {
        SceneManager.LoadScene("Medium");
    }   
    public void LoadHard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void LoadRange()
    {
        SceneManager.LoadScene("Range");
    }
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
