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
    public GameObject body;
    public GameObject deathMenu;
    void Start()
    {
        currantHealth = maxHealth;
        if (gameObject.tag == "Player")
        {
            deathMenu.SetActive(false);
        }
    }
    private void Update()
    {
        if (gameObject.tag == "Player")
        {
            healthDisplay.text = currantHealth.ToString("0");
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
            PlayerDie();
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
        if (gameObject.tag == "Head")
        {
            KillLogic.kills++;
            Destroy(body);
        }
        if (gameObject.tag == "Enemy")
        {
            KillLogic.kills++;
            Destroy(gameObject);
        }
    }
    public void PlayerDie()
    {
        if (gameObject.tag == "Player")
        {
            deathMenu.SetActive(true);
            Destroy(body);
            return;
        }
    }
    public void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
