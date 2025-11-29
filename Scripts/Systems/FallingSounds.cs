using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSounds : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

    public AudioSource droppedOffice;
    public AudioSource droppedBasement;
    public AudioSource droppedOutside;
    public AudioSource droppedDeath;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0 || other.gameObject.layer == 3 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 23 || other.gameObject.layer == 24 || other.gameObject.layer == 30 || other.gameObject.layer == 31)//31 == floor
        {
            Dropped();
        }
    }
    public void Dropped()
    {
        if (playerS.inOffice == true)
        {
            droppedOffice.Play();
        }
        if (playerS.inBasement == true)
        {
            droppedBasement.Play();
        }
        if (playerS.inOutside == true)
        {
            droppedOutside.Play();
        }
        if (playerS.inDeath == true)
        {
            droppedDeath.Play();
        }
    }
}
