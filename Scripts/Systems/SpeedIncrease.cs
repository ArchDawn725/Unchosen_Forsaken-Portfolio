using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

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
        if (other.gameObject.tag == "Hand")
        {
            if (!used)
            {
                itemUse.SetActive(true);
                playerS.currentSpeed += 0.05f;
                playerS.maxEnergy += 0.5f;
                rend.enabled = false;
                Invoke("Delay", 1);
            }
        }

    }

    public void Delay()
    {
        Destroy(this.gameObject);
    }
}
