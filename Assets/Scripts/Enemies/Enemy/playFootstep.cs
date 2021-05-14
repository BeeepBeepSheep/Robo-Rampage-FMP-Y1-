using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playFootstep : MonoBehaviour
{
    public AudioSource punch;
    void Start()
    {
        //punch = GetComponent<AudioSource>();
    }
    public void PlayPunch()
    {
        punch.Play();
    }
}
