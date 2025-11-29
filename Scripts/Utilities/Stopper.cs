using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopper : MonoBehaviour
{
    public Collider collider;

    public bool destroyOther;
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delay", 5);
        Invoke("Delay2", 10);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (destroyOther)
        {
            Destroy(thing);
        }
        Destroy(this.gameObject);
    }

    public void Delay()
    {
        collider.enabled = true;
    }

    public void Delay2()
    {
        Destroy(this);
    }
}
