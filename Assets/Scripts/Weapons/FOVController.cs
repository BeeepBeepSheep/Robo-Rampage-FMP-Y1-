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

    public GameObject StopADS;

    public Animator anim;
    void Start()
    {
        cam.fieldOfView = mainFov;
    }


    void Update()
    {

        //sprinting fov
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            cam.fieldOfView = mainFov;
            anim.SetBool("IsSprinting", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.fieldOfView = mainFov + 10f;
            anim.SetBool("IsSprinting", true);
            return;
        }
        if(StopADS.activeInHierarchy == true)
        {
            //Debug.Log("cant ads");
            return;
        }

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
    }
}
