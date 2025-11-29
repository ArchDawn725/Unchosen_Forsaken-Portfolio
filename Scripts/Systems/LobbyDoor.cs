using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDoor : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

    public GameObject door2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        if (playerS.leverPulled == true)
        {
            Destroy(this.gameObject);
            door2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
