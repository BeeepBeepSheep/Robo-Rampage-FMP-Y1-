using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Settings : MonoBehaviour
{
    public bool promptsIsActive;
    public bool isFullScreen = false;
    public GameObject fullscreenTick;

    public GameObject prompts;
    public GameObject promptsTick;

    public Slider sensSlider;
    public Text liveSens;

    public Slider masterVolSlider;
    public Text liveMasterVol;
    public AudioMixer masterMixer;

    private float a;
    private float b;

    public Slider musicVolSlider;
    public Text liveMusicVol;
    public AudioMixer musicMixer;
    private float c;
    private float d;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currantResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currantResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currantResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        FullScreen_Toggle();
        prompts.SetActive(true);
        promptsIsActive = true;
    }
    void Update()
    {
        liveSens.text = sensSlider.value.ToString();
    }
    public void Set_MasterVolume(float volume)
    {
        masterMixer.SetFloat("masterVolume", volume);

        a = masterVolSlider.value + 80f;
        b = masterVolSlider.maxValue + 80f;
        liveMasterVol.text = Mathf.RoundToInt((a/b)*100).ToString() + "%";

        //liveMasterVol.text = masterVolSlider.value.ToString();
    }
    public void Set_MusicVolume(float volume)
    {
        musicMixer.SetFloat("musicVol", volume);

        c = musicVolSlider.value + 80f;
        d = musicVolSlider.maxValue + 80f;
        liveMusicVol.text = Mathf.RoundToInt((c / d) * 100).ToString() + "%";
        //liveMusicVol.text = musicVolSlider.value.ToString();
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
    public void Set_Resolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);
    }
    public void FullScreen_Toggle()
    {
        if (isFullScreen)
        {
            isFullScreen = false;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(false);
            //Debug.Log("fullscreen" + isFullScreen.ToString());
        }
        else
        {
            isFullScreen = true;
            Screen.fullScreen = isFullScreen;
            fullscreenTick.SetActive(true);
            //Debug.Log("fullscreen" + isFullScreen.ToString());
        }
    }
}
