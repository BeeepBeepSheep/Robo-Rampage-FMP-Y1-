using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float mainFov;

    public Camera cam;

    void start()
    {
        cam = this.GetComponent;
        mainFov = cam.fieldOfView;
    }
    void ResetFov()
    {
        cam.FieldOfView = mainFov;
    }
}
