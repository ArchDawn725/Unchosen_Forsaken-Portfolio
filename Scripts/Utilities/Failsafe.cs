using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failsafe : MonoBehaviour
{
    public Player player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.OnStartOver();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
