using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider reload)
    {
        Debug.Log("Restarted due to fall");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
