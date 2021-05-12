using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currantHealth = 0f;
    public float maxHealth = 100f;
    public GameObject healthBar;
    public Image playerHealthBar;
    public GameObject lowHealthIndicator;
    public GameObject body;
    public GameObject deathMenu;

    public static bool isBlocking = false;

    public Color red;
    public Color green;


    void Start()
    {
        currantHealth = maxHealth;
        if (gameObject.tag == "PlayerCapsual")
        {
            playerHealthBar.color = green;
            deathMenu.SetActive(false);
        }
    }
    private void Update()
    {
        if (gameObject.tag == "PlayerCapsual")
        {
            playerHealthBar.fillAmount = currantHealth / maxHealth;
            if (currantHealth <= 25f)
            {
                lowHealthIndicator.SetActive(true);
                playerHealthBar.color = red;
            }
            else
            {
                lowHealthIndicator.SetActive(false);
                playerHealthBar.color = green;
            }
        }
    }
    public void TakeDamage(float amount)
    {
        if(isBlocking /*&& gameObject.tag == "PlayerCapsual"*/)
        {
            Debug.Log("Blocking");
            return;
        }
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
            body.tag = "Enemy";
            KillLogic.kills++;
            //body.SetActive(false);
            Destroy(body);
        }
        if (gameObject.tag == "Enemy")
        {
            gameObject.tag = "DeadEnemy";
            KillLogic.kills++;
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void PlayerDie()
    {
        if (gameObject.tag == "PlayerCapsual")
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
