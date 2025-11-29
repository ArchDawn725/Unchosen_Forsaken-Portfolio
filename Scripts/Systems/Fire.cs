using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public GameObject fireEffect;
    public GameObject fireLight;
    public Collider fireCollider;

    public int timer;
    public float time;

    public bool activated;
    public bool burntOut;

    public bool activatable;

    public bool isMatch;

    public AudioSource igniteOffice;
    public AudioSource igniteBasement;
    public AudioSource igniteOutside;
    public AudioSource igniteDeath;

    public AudioSource fireOffice;
    public AudioSource fireBasement;
    public AudioSource fireOutside;

    public GameObject player;
    public Player playerS;

    public AudioSource droppedOffice;
    public AudioSource droppedBasement;
    public AudioSource droppedOutside;
    public AudioSource droppedDeath;

    public Holder holder;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        StartCoroutine(FireTimer());
        //Activate();
    }

    public void Activate()
    {
        if (!activated)
        {
            fireEffect.SetActive(true);
            fireLight.SetActive(true);
            fireCollider.enabled = true;
            activated = true;
            Click();
            holder.enabled = false;
        }
        else if (activatable)
        {
            fireEffect.SetActive(false);
            fireLight.SetActive(false);
            fireCollider.enabled = false;
            Deactivate();
            activated = false;
        }
    }

    IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(1);
        while (activated)
        {
            yield return new WaitForSeconds(1);
            if (time < timer)
            {
                time++;
                //StartCoroutine(FireTimer());
            }
            else
            {
                fireEffect.SetActive(false);
                fireLight.SetActive(false);
                fireCollider.enabled = false;
                Deactivate();
                burntOut = true;
            }
        }
        StartCoroutine(FireTimer());
    }

    public void Click()
    {
        if (playerS.inOffice == true)
        {
            igniteOffice.Play();
            fireOffice.enabled = true;
            fireBasement.enabled = false;
            fireOutside.enabled = false;
        }
        if (playerS.inBasement == true)
        {
            igniteBasement.Play();
            fireBasement.enabled = true;
            fireOffice.enabled = false;
            fireOutside.enabled = false;
        }
        if (playerS.inOutside == true)
        {
            igniteOutside.Play();
            fireOutside.enabled = true;
            fireBasement.enabled = false;
            fireOffice.enabled = false;
        }
        if (playerS.inDeath == true)
        {
            igniteDeath.Play();

            fireOffice.enabled = false;
            fireOutside.enabled = false;
            fireBasement.enabled = false;
        }
    }

    public void Deactivate()
    {
        fireOffice.enabled = false;
        fireOutside.enabled = false;
        fireBasement.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 0 || other.gameObject.layer == 3 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 23 || other.gameObject.layer == 24 || other.gameObject.layer == 30 || other.gameObject.layer == 31)//31 == floor
        {
            Dropped();
        }

        if (other.gameObject.tag == "Death")
        {
            time = 1000;
        }
    }

    public void Dropped()
    {
        if (playerS.inOffice == true)
        {
            droppedOffice.Play();
        }
        if (playerS.inBasement == true)
        {
            droppedBasement.Play();
        }
        if (playerS.inOutside == true)
        {
            droppedOutside.Play();
        }
        if (playerS.inDeath == true)
        {
            droppedDeath.Play();
        }
    }
}
