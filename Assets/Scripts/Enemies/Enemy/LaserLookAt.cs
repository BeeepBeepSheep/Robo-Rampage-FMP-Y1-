using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLookAt : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        target = PlayerManeger.instance.player.transform;
    }

    void Update()
    {
        Vector3 direcetion = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direcetion);
        transform.rotation = rotation;
    }
}
