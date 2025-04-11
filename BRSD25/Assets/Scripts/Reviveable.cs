using PurrNet;
using UnityEngine;

public class Reviveable : NetworkBehaviour
{
    public GameObject toSpwan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ReviveChar()
    {
        Instantiate(toSpwan, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
