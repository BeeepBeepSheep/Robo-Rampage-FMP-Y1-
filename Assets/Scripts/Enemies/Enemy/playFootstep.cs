using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playFootstep : MonoBehaviour
{
    AudioSource step;
    void Start()
    {
        step = GetComponent<AudioSource>();
    }
    public void PlayStep()
    {
        step.Play();
    }
}
