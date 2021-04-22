using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public GameObject player1;
    private void OnTriggerEnter(Collider reload)
    {
        Health player = player1.GetComponent<Health>();
        player.TakeDamage(100);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
