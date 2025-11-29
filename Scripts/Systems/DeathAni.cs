using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAni : MonoBehaviour
{

    public GameObject sounds;
    public GameObject sounds2;
    public Animation referenceToAnimation;

    public bool secondarySound;
    public float delayTimer;

    public bool test;

    public bool specialAni;

    public Animation ani2;
    public Animation ani3;
    public Animation ani4;
    public Animation ani5;
    public Animation ani6;


    public void Start()
    {
        if (test)
        {
            LookingAtMe();
        }
    }

    public void LookingAtMe()
    {
        sounds.SetActive(true);
        referenceToAnimation.Play();
        if (secondarySound)
        {
            Invoke("SecondarySound", delayTimer);
        }
        if (specialAni)
        {
            StartCoroutine(Ani());
        }
    }

    public void SecondarySound()
    {
        sounds2.SetActive(true);
    }

    IEnumerator Ani()
    {
        yield return new WaitForSeconds(0.5f);
        ani2.Play();
        yield return new WaitForSeconds(0.5f);
        ani3.Play();
        yield return new WaitForSeconds(0.5f);
        ani4.Play();
        yield return new WaitForSeconds(0.5f);
        ani5.Play();
        yield return new WaitForSeconds(0.5f);
        ani6.Play();
    }
}
