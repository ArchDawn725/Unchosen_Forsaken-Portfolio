using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTimer : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

    public int timer = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        if(playerS.choosenLevel != 5)
        {
            Invoke("StartGame", 1);
        }
        else
        {
            Invoke("StartGame", timer);
        }

        playerS.currentSpeed = 0;
    }

    public void StartGame()
    {
        playerS.hour = 6; playerS.minute = 0;


        if (playerS.choosenLevel == 1)
        {
            playerS.currentSpeed = 1.5f;
            playerS.SecondFloorTeleport();
        }
        if (playerS.choosenLevel == 2)
        {
            playerS.currentSpeed = 1.75f;
            playerS.BasementTeleport();
        }
        if (playerS.choosenLevel == 3)
        {
            playerS.currentSpeed = 2f;
            playerS.OutsideTeleport();
        }
        if (playerS.choosenLevel == 4)
        {
            playerS.currentSpeed = 1.5f;
            playerS.EndTeleport();
        }
        if (playerS.choosenLevel == 5)
        {
            playerS.currentSpeed = 1.5f;
            playerS.OnStartOver();
        }

    }
}
