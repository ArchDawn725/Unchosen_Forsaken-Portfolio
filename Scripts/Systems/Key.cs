using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Elevator elevator;

    public GameObject player;
    public Player playerS;

    public AudioSource droppedOffice;
    public AudioSource droppedBasement;
    public AudioSource droppedOutside;
    public AudioSource droppedDeath;

    public GameObject itemUse;
    public Renderer rend;

    public bool used;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Elevator")
        {
            if (!used)
            {
                itemUse.SetActive(true);
                elevator = other.GetComponent<Elevator>();
                elevator.Activate();
                rend.enabled = false;
                Invoke("Delay", 1);
            }

        }
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

    public void Delay()
    {
        Destroy(this.gameObject);
    }
}
