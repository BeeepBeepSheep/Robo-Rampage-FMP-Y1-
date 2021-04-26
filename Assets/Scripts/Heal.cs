using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Animator anim;
    public GameObject player1;


    void OnEnable()
    {
        anim.SetBool("IsHealing", false);
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("healing");
            anim.SetBool("IsHealing", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("IsHealing", false);
        }
    }
}
