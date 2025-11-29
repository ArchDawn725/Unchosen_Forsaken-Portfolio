using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWater : MonoBehaviour
{
    public bool isWater;
    public bool isGrass;

    public Player player;

    public bool Done = true;

    public void Start()
    {
        if (!Done)
        {
            Invoke("Delay", 15);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<Collider>().GetComponent<Player>();
            if (isWater)
            {
                player.onWater = true;
            }
            else if (isGrass)
            {
                player.onGrass = true;
            }
            else
            {
                player.onWater = false;
                player.onGrass = false;
            }
        }
    }

    public void Delay()
    {
        GetComponent<Collider>().enabled = true;
    }
}
