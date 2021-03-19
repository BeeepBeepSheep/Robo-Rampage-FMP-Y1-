using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //sensitivity
    public float mouseSensitivity;
    public float normalSensitivity;
    public float aimSensitivity;

    //guns
    public GameObject aimingGun;
    public GameObject notAimingGun;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        mouseSensitivity = normalSensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //looking
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //aiming
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            mouseSensitivity = aimSensitivity;
            notAimingGun.SetActive(false);
            aimingGun.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            mouseSensitivity = normalSensitivity;
            notAimingGun.SetActive(true);
            aimingGun.SetActive(false);
        }
    }
}
