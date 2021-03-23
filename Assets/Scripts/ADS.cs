using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{
    //guns
    public GameObject aimingGun;
    public GameObject notAimingGun;

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
            aimingGun.SetActive(true);
            notAimingGun.SetActive(false);

            Dot.SetActive(true);
            Cross.SetActive(false);

            cam.fieldOfView = mainFov - 10f;

        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aimingGun.SetActive(false);
            notAimingGun.SetActive(true);

            Dot.SetActive(true);
            Cross.SetActive(false);

            cam.fieldOfView = mainFov;
        }
    }
}
