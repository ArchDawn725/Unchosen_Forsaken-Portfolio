using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Light light;
    public GameObject music;
    public bool isActive;

    public GameObject player;
    public Player playerS;

    public int levelsWon;

    public Renderer on;
    public Renderer off;

    public Animation referenceToAnimation;
    public AnimationClip[] clips;

    public int level;
    private float number;
    public void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        levelsWon = PlayerPrefs.GetInt("levelsWon");
        level = playerS.choosenLevel;

        number = light.intensity;
        light.intensity = number / 5;

        OpenDoors();
        if (isActive)
        {
            Activate();
        }

    }

    public void Activate()
    {
        light.enabled = true;
        isActive = true;
        music.SetActive(true);
        on.enabled = true;
        off.enabled = false;
    }

    public void OutsideFloorPress()
    {
        if (level == 3)
        {
            OpenDoors();
        }
        else if (isActive && playerS.leverPulled == true && level == 2)
        {
            if (levelsWon == 1)
            {
                PlayerPrefs.SetInt("levelsWon", 2);
            }
            Deactivate();
            playerS.OutsideTeleport();
        }
    }

    public void FirstFloorPress()
    {
        if (level == 1)
        {
            OpenDoors();
        }

        /*
        else if (isActive)
        {
            Deactivate();
            playerS.SecondFloorTeleport();
        }
        */
    }

    public void BasementPress()
    {
        if (level == 2)
        {
            OpenDoors();
        }

        else if (isActive && level == 1)
        {
            if (levelsWon == 0)
            {
                PlayerPrefs.SetInt("levelsWon", 1);
            }
            Deactivate();
            playerS.BasementTeleport();
        }
    }

    public void OpenDoors()
    {
        referenceToAnimation.clip = clips[0];
        referenceToAnimation.Play();
        Invoke("CloseDoors", 60);
        print("open");
    }

    public void CloseDoors()
    {
        referenceToAnimation.clip = clips[1];
        referenceToAnimation.Play();
    }

    public void Deactivate()
    {
        CloseDoors();
        isActive = false;
        Invoke("LightsOut", 3);
    }

    public void LightsOut()
    {
        light.enabled = false;
        music.SetActive(false);
        on.enabled = false;
        off.enabled = true;
    }
}
