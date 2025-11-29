using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterFog : MonoBehaviour
{
    public GameObject player;
    public Transform teleport;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            player.transform.position = teleport.position;
        }
    }
}
