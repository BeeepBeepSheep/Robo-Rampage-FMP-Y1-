using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabDeathMenu : MonoBehaviour
{
    public GameObject hud;
    public GameObject weaponHolder;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        weaponHolder.SetActive(false);
    }
}
