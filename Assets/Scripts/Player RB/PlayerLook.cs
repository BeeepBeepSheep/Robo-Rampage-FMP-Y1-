using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //    public Transform playerBody;
    //    public float mouseSensitivity = 100f;

    //    private float xRotation = 0f;
    //    private float yRotation = 0f;


    //    void Start()
    //    {

    //    }


    //    void Update()
    //    {
    //        xRotation += Input.GetAxis("Mouse Y" * mouseSensitivity);
    //        yRotation += Input.GetAxis("Mouse X" * mouseSensitivity);

    //        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //        transform.localRotaition = Quaternion.Euler(xRotation, 0f, 0f);
    //        playerBody.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);

    //    }
    public float mouseSensitivity = 500f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
