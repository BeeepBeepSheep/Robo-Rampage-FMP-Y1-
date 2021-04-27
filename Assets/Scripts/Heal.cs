using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    public Animator anim;
    public GameObject player1;
    public float healRate = 5f;
    private float nextTimeToHeal = 0f;

    public float totalHealAmmount = 50f;
    public float currantHealAmmount;
    public Text healAmmountDisplay;

    public float doHealValue = 1f;

    public GameObject HealingIndicator;

    void Start()
    {
        currantHealAmmount = totalHealAmmount;
    }
    void OnEnable()
    {
        anim.SetBool("IsHealing", false);
        HealingIndicator.SetActive(false);
    }
    void Update()
    {
        healAmmountDisplay.text = currantHealAmmount.ToString();
        if (currantHealAmmount <= 0)
        {
            anim.SetBool("IsHealing", false);
            HealingIndicator.SetActive(false);
            return;
        }

        Health player = player1.GetComponent<Health>();
        if (player.currantHealth >=100)
        {
            player.currantHealth = 100f;
            anim.SetBool("IsHealing", false);
            HealingIndicator.SetActive(false);
            return;
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToHeal)
            {
                nextTimeToHeal = Time.time + 1f / healRate;
                IncreaseHealth();
                anim.SetBool("IsHealing", true);
                HealingIndicator.SetActive(true);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                anim.SetBool("IsHealing", false);
                HealingIndicator.SetActive(false);
            }
        }
    }

    void IncreaseHealth()
    {
        Debug.Log("healing");
        currantHealAmmount = currantHealAmmount - doHealValue;
        Health player = player1.GetComponent<Health>();
        player.TakeDamage(-doHealValue);
    }
}
