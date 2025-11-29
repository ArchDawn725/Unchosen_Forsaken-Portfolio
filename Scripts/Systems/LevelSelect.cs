using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public LevelPicker level;

    public enum Floor
    {
        secondFloor,
        basementFloor,
        outsideFloor
    }

    public Floor floor;

    public GameObject player;
    public Player playerS;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (floor == Floor.secondFloor)
            {
                playerS.SecondFloorChoice();
            }
            if (floor == Floor.basementFloor)
            {
                playerS.BasementChoice();
            }
            if (floor == Floor.outsideFloor)
            {
                playerS.OutsideChoice();
            }
        }
    }
}
