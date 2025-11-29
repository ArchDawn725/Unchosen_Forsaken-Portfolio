using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject eve;
    public GameObject shadow;
    public GameObject shook;
    public GameObject stalker;
    public GameObject mother;
    public GameObject spider;
    public GameObject head;
    public GameObject watcher;

    public GameObject light;

    public void isShadow()
    {
        shadow.SetActive(true);
    }

    public void isShook()
    {
        shook.SetActive(true);
    }

    public void isStalker()
    {
        stalker.SetActive(true);
    }

    public void isMother()
    {
        mother.SetActive(true);
    }

    public void isSpider()
    {
        spider.SetActive(true);
    }

    public void isHead()
    {
        head.SetActive(true);
    }

    public void isWatcher()
    {
        watcher.SetActive(true);
    }

    public void IsEve()
    {
        light.SetActive(false);
        eve.SetActive(true);
    }
}
