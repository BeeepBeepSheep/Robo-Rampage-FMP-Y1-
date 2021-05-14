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
    public GameObject explosion;
    public AudioSource oof;

    private bool mainMusicCanPlay;
    public AudioSource mainMusic;
    private bool lowHealthMusicCanPlay;
    public AudioSource lowHealthMusic;

    public static bool isBlocking = false;

    public Color red;
    public Color green;


    void Start()
    {
        currantHealth = maxHealth;
        explosion = GameObject.FindGameObjectWithTag("explosion");
        if (gameObject.tag == "PlayerCapsual")
        {
            mainMusic.loop = true;
            mainMusic.Play();
            lowHealthMusic.loop = false;
            lowHealthMusic.Stop();

            lowHealthMusicCanPlay = true;
            mainMusicCanPlay = false;

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
                mainMusic.loop = false;
                mainMusic.Pause();
                lowHealthMusic.loop = true;
                if (lowHealthMusicCanPlay)
                {
                    lowHealthMusic.Play();
                    lowHealthMusicCanPlay = false;
                    mainMusicCanPlay = true;
                }


                lowHealthIndicator.SetActive(true);
                playerHealthBar.color = red;
            }
            else
            {
                lowHealthMusic.loop = false;
                lowHealthMusic.Stop();
                mainMusic.loop = true;
                if (mainMusicCanPlay)
                {
                    mainMusic.UnPause();
                    lowHealthMusicCanPlay = true;
                    mainMusicCanPlay = false;
                }


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
        if(gameObject.tag == "PlayerCapsual")
        {
            oof.Play();
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
        if (gameObject.tag == "Enemy")
        {
            gameObject.tag = "DeadEnemy";
            GameObject impactGameObject = Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(impactGameObject, 1f);

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
