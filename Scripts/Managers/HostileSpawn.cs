using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawn : MonoBehaviour
{
    public bool isHusk;

    public void Start()
    {
        if (this.gameObject.tag == "HuskSpawner")
        {
            isHusk = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isHusk)
        {
            if (other.gameObject.tag == "Hostile" || other.gameObject.tag == "Player" || other.gameObject.tag == "HeartBeat" || other.gameObject.tag == "SafeZone")
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "HeartBeat" || other.gameObject.tag == "SafeZone")
            {
                Destroy(this.gameObject);
            }
        }

    }
}
