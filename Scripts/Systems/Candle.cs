using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{

    public GameObject player;
    public Player playerS;

    public AudioSource fireOffice;
    public AudioSource fireBasement;
    public AudioSource fireOutside;
    public AudioSource fireStart;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;

        if (playerS.inOffice == true)
        {
            fireOffice.enabled = true;
        }
        if (playerS.inBasement == true)
        {
            fireBasement.enabled = true;
        }
        if (playerS.inOutside == true)
        {
            fireOutside.enabled = true;
        }
        if (playerS.inStart == true)
        {
            fireStart.enabled = true;
        }
    }
}
