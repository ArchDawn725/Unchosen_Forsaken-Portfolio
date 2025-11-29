using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public Player playerS;

    public void OnTriggerEnter(Collider other)
    {
        //needs imrovement
        if (other.gameObject.tag == "Player")
        {
            playerS = other.GetComponent("Player") as Player;
            print("Tag");
            playerS.EndTeleport();
        }
    }
}
