using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeleter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "Battery" || other.gameObject.tag == "Oil")
        {
            Destroy(this.gameObject);
        }
    }
}
