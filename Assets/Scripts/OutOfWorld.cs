using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfWorld : MonoBehaviour
{


    private void OnTriggerEnter(Collider outOfBounds)
    {
        if (outOfBounds.gameObject.tag == "OutOfBounds")
        {
            Debug.Log("Reloaded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
