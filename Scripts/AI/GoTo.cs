using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoTo : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject marker;
    public Renderer rend;
    public Animation referenceToAnimation;

    public void Delay()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.destination = marker.transform.position;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        //needs imrovement
        if (other.gameObject.tag == "Player")
        {
            if (referenceToAnimation != null)
            {
                referenceToAnimation.Play();
            }

            Invoke("Delay", 2);
        }
        if (other.gameObject.tag == "Hostile")
        {
            rend.enabled = false;
        }
    }
}
