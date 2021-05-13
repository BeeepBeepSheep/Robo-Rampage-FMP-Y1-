using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool promptsIsActive;
    public GameObject prompts;
    public GameObject promptsTick;
    void Start()
    {
        prompts.SetActive(true);
        promptsIsActive = true;
    }
    void Update()
    {
        
    }
    public void Prompts_Toggle()
    {
        if(promptsIsActive)
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
}
