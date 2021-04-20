using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currantHealth = 0f;
    public float maxHealth = 100f;
    public GameObject healthBar;
    public Text healthDisplay;
    void Start()
    {
        currantHealth = maxHealth;
    }
    private void Update()
    {
        healthDisplay.text = currantHealth.ToString();
    }
    public void TakeDamage(float amount)
    {
        currantHealth -= amount;

        float calcHealth = currantHealth / maxHealth;
        //SetHealthBar(calcHealth);

        if(currantHealth <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    //public void SetHealthBar(float myHealth)
    //{
    //    healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    //}
}
