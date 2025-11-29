using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSensor : MonoBehaviour
{
    public bool isFar;
    public bool isMid;
    public bool isClose;

    public HeartBeat heart;

    public int hostiles;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hostile")
        {
            if (isClose)
            {
                hostiles++;
                heart.monstersClose = hostiles;
            }
            if (isMid)
            {
                hostiles++;
                heart.monstersMid = hostiles;
            }
            if (isFar)
            {
                hostiles++;
                heart.monstersFar = hostiles;
            }
        }

        if (other.gameObject.tag == "Death")
        {
            heart.inDeath = true;
            heart.monstersClose = 0;
            heart.monstersMid = 0;
            heart.monstersFar = 0;
        }

        if (other.gameObject.tag == "SafeZone")
        {
            heart.inStart = false;
        }

        if (other.gameObject.tag == "Start")
        {
            heart.inDeath = false;
            heart.inStart = true;
        }

        if (hostiles < 0)
        {
            hostiles = 0;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hostile")
        {
            if (isClose)
            {
                hostiles--;
                heart.monstersClose = hostiles;
            }
            if (isMid)
            {
                hostiles--;
                heart.monstersMid = hostiles;
            }
            if (isFar)
            {
                hostiles--;
                heart.monstersFar = hostiles;
            }
        }

        if (hostiles < 0)
        {
            hostiles = 0;
        }
    }
}
