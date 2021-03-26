using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVController : MonoBehaviour
{
    //cross hair
    public GameObject Dot;
    public GameObject Cross;

    public Camera cam;
    public float mainFov = 70f;

    void Start()
    {
        cam.fieldOfView = mainFov;
    }


    void Update()
    {
        //aiming
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Dot.SetActive(true);
            Cross.SetActive(false);

            cam.fieldOfView = mainFov - 10f;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Dot.SetActive(false);
            Cross.SetActive(true);

            cam.fieldOfView = mainFov;
        }

        //sprinting fov
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cam.fieldOfView = mainFov + 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cam.fieldOfView = mainFov;
        }
    }
}
