using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Animator anim;
    public GameObject player1;
    public float healRate = 5f;
    private float nextTimeToHeal = 0f;
    public float healAmmount = 1;

    void OnEnable()
    {
        anim.SetBool("IsHealing", false);
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToHeal)
        {
            nextTimeToHeal = Time.time + 1f / healRate;
            IncreaseHealth();
            anim.SetBool("IsHealing", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("IsHealing", false);
        }
    }

    void IncreaseHealth()
    {
        Debug.Log("healing");
        //heal player health 
        Health player = player1.GetComponent<Health>();
        player.TakeDamage(-healAmmount);
    }
}
