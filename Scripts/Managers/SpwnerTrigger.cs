using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnerTrigger : MonoBehaviour
{
    public GameObject particleSystem;
    public GameObject Eve;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            particleSystem.SetActive(false);
            Invoke("SpawnEntity", 10);
        }
    }

    public void SpawnEntity()
    {
        Instantiate(Eve, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
