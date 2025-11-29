using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int hits;

    public Animation referenceToAnimation;
    public AnimationClip[] clips;

    public GameObject player;
    public Player playerS;

    public GameObject idle;
    public GameObject hit;
    public GameObject walk;
    public GameObject enter;


    public void Start()
    {
        Invoke("StartRoutine", 5);
    }

    public void StartRoutine()
    {
        enter.SetActive(true);
        walk.SetActive(true);
        referenceToAnimation.clip = clips[0];
        referenceToAnimation.Play();
        StartCoroutine(Controller());
        Invoke("Idle", 10);
    }

    public void Hit()
    {
        if (hits < 4)
        {
            referenceToAnimation.clip = clips[2];
            referenceToAnimation.Play();
            hit.SetActive(true);
            enter.SetActive(false);
            Invoke("Idle", 20);
        }

    }

    public void Flee()
    {
        referenceToAnimation.clip = clips[3];
        referenceToAnimation.Play();
        enter.SetActive(true);
        walk.SetActive(true);
        Invoke("Win", 20);
    }

    IEnumerator Controller()
    {
        yield return new WaitForSeconds(1);
        if (hits > 3)
        {
            Flee();
        }
        else
        {
            StartCoroutine(Controller());
        }
    }

    public void Idle()
    {
        if (hits < 4)
        {
            referenceToAnimation.clip = clips[1];
            referenceToAnimation.Play();
            idle.SetActive(true);
            hit.SetActive(false);
            walk.SetActive(false);
        }

    }

    public void Win()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        playerS.CreditsTeleport();
    }
}


