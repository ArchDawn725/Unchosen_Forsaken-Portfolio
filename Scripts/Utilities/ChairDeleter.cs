using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairDeleter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //needs imrovement
        if (other.gameObject.tag == "Chair")
        {
            Destroy(other.gameObject);
        }
    }
}
