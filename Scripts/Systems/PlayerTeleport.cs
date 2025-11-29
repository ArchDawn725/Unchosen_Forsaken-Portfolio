using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;

        player.transform.position = this.gameObject.transform.position;
        playerS.Disable();
    }
}
