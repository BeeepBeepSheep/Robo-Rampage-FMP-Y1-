using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabDeathMenu : MonoBehaviour
{
    public GameObject hud;
    public GameObject weaponHolder;
    void Start()
    {
        hud.SetActive(true);
        weaponHolder.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        weaponHolder.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
