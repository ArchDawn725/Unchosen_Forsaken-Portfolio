using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource calm;
    public AudioSource timeout;

    public bool timeOver;

    public Player players;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        players = player.GetComponent("Player") as Player;
        MusicPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (players.hour < 3)
        {
            timeOver = true;
            MusicPlay();
        }
        else
        {
            timeOver = false;
            MusicPlay();
        }
    }

    public void MusicSwitch()
    {

    }

    public void MusicStop()
    {
        calm.enabled = false;
        timeout.enabled = false;
    }

    public void MusicPlay()
    {
        if (timeOver == false)
        {
            calm.enabled = true;
            timeout.enabled = false;
        }
        else
        {
            calm.enabled = false;
            timeout.enabled = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hostile")
        {
            MusicStop();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hostile")
        {
            MusicPlay();
        }
    }
}
