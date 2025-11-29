using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSounds : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

    //public GameObject[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = player.transform.position;
    }
}
