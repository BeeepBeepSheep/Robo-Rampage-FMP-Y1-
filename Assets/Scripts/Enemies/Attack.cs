using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 10f;
    public bool attacking;
    public Animator animator;
    public GameObject player1;
    public GameObject damageIndicator;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_Arm_1"))
        {
            if (attacking)
            {
                return;
            }
            StartCoroutine(DoDamage());
        }
    }
    IEnumerator DoDamage()
    {
        attacking = true;
        yield return new WaitForSeconds(.50f);
        damageIndicator.SetActive(true);

        yield return new WaitForSeconds(.25f);
        Health player = player1.GetComponent<Health>();
        player.TakeDamage(damage);
        Debug.Log("takes damage");

        yield return new WaitForSeconds(.25f);
        damageIndicator.SetActive(false);
        attacking = false;
    }
}
