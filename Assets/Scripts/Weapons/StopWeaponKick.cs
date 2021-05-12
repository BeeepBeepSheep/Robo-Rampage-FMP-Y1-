using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWeaponKick : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Shooting", false);
        }
    }
}
