using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVController : MonoBehaviour
{
    //cross hair
    public GameObject Dot;
    public GameObject Cross;

    public Camera cam;
    private float mainFov = 70f;

    public GameObject StopADS;

    public Animator anim;
    public Text fovText;
    void Start()
    {
        cam.fieldOfView = mainFov;
    }

    void Update()
    {
        //cam.fieldOfView = mainFov;
        fovText.text = mainFov.ToString();
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
    public void Ajust_FOV(float newFOV)
    {
        mainFov = newFOV;
        cam.fieldOfView = mainFov;
    }
}
