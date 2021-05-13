using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool promptsIsActive;
    public bool isFullScreen;
    public GameObject prompts;
    public GameObject promptsTick;
    public GameObject fullscreenTick;
    void Start()
    {
        isFullScreen = false;
        FullScreen_Toggle();
        prompts.SetActive(true);
        promptsIsActive = true;
    }
    void Update()
    {

    }
    public void Prompts_Toggle()
    {
        if (promptsIsActive)
        {
            prompts.SetActive(false);
            promptsIsActive = false;
            promptsTick.SetActive(false);
        }
        else
        {
            prompts.SetActive(true);
            promptsIsActive = true;
            promptsTick.SetActive(true);
        }
    }
    public void FullScreen_Toggle()
    {
        if (isFullScreen)
        {
            isFullScreen = false;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(false);
            Debug.Log("fullscreen" + isFullScreen.ToString());
        }
        else
        {
            isFullScreen = true;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(true);
            Debug.Log("fullscreen" + isFullScreen.ToString());
        }
    }
}
