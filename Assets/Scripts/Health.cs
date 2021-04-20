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
    public GameObject lowHealthIndicator;
    void Start()
    {
        currantHealth = maxHealth;
    }
    private void Update()
    {
        if (gameObject.tag == "Player")
        {
            healthDisplay.text = currantHealth.ToString();
            if (currantHealth <= 25f)
            {
                lowHealthIndicator.SetActive(true);
            }
            else
            {
                lowHealthIndicator.SetActive(false);
            }
        }
    }
    public void TakeDamage(float amount)
    {
        currantHealth -= amount;
        if (currantHealth <= 0f)
        {
            Die();
        }
        if (gameObject.tag == "Enemy")
        {
            float calcHealth = currantHealth / maxHealth;
            SetHealthBar(calcHealth);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
