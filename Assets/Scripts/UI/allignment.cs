using UnityEngine;
using UnityEngine.UI;

public class allignment : MonoBehaviour
{
    public Transform target;
    public float xOffset;
    public float yOffset;
    void Start()
    {
        transform.position = target.position - new Vector3(xOffset, yOffset, 0f);
    }
}
