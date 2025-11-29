using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public Hostile2 hostile;
    public bool flashlightOn;
    public GameObject light;

    public AudioSource clickOffice;
    public AudioSource clickBasement;
    public AudioSource clickOutside;
    public AudioSource clickDeath;

    public float batteryLife;
    public float lightDistance;

    public TextMeshPro batteryLifeText;
    public float batterLifeDisplay;
    public float drainSpeed = 0.05f;

    public bool inDeath;

    public bool seenHostile;
    public bool saw1;
    public bool saw2;
    public bool saw3;
    public bool saw4;
    public bool saw5;
    public bool saw6;
    public bool saw7;
    public bool saw8;
    public bool saw9;

    public float LuckyNumber;

    public GameObject player;
    public Player playerS;

    public bool strobelight;
    public Holder holder;

    public AudioSource droppedOffice;
    public AudioSource droppedBasement;
    public AudioSource droppedOutside;
    public AudioSource droppedDeath;

    public LayerMask colliderLayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        StartCoroutine(RandomNumber());
        StartCoroutine(BatteryDrain());
        StartCoroutine(Strobing());

        //FlashlightSwitch();
    }

    // Update is called once per frame
    void Update()
    {

        batterLifeDisplay = Mathf.Round(batteryLife);
        batteryLifeText.text = (batterLifeDisplay.ToString() + "%");
        if (batteryLife > 100)
        {
            batteryLife = 100;
        }

        if (flashlightOn)
        {
            if (batteryLife > 0)
            {
                light.SetActive(true);

                if (saw1 == false && saw2 == false && saw3 == false && saw4 == false && saw5 == false && saw6 == false && saw7 == false && saw8 == false && saw9 == false)
                {
                    seenHostile = false;
                }
            }
            else
            {
                light.SetActive(false);
                seenHostile = false;
                strobelight = false;
            }
        }
        else
        {
            light.SetActive(false);
            seenHostile = false;
            strobelight = false;
        }
    }

    public void FlashlightSwitch()
    {
        if (flashlightOn || inDeath)
        {
            flashlightOn = false;
            seenHostile = false;

        }
        else if (batteryLife > 0)
        {
            flashlightOn = true;
        }
        else
        {
            flashlightOn = false;
            seenHostile = false;
        }
        Click();
    }

    IEnumerator BatteryDrain()
    {
        while (flashlightOn)
        {
            yield return new WaitForSeconds(0.1f);
            batteryLife -= drainSpeed;
            if (strobelight)
            {
                batteryLife -= drainSpeed*2;
            }
            if (batteryLife < 0)
            {
                flashlightOn = false;
            }
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(BatteryDrain());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            batteryLife += 100;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Death")
        {
            inDeath = true;
            FlashlightSwitch();
        }
        
        if (other.gameObject.layer == 0 || other.gameObject.layer == 3 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 23 || other.gameObject.layer == 24 || other.gameObject.layer == 30 || other.gameObject.layer == 31)//31 == floor
        {
            Dropped();
        }
    }

    IEnumerator RandomNumber()
    {
        while (seenHostile)
        {
            yield return new WaitForSeconds(1);
            LuckyNumber = Random.Range(0, 100);
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(RandomNumber());
    }

    public void Click()
    {
        if (playerS.inOffice == true)
        {
            clickOffice.Play();
        }
        if (playerS.inBasement == true)
        {
            clickBasement.Play();
        }
        if (playerS.inOutside == true)
        {
            clickOutside.Play();
        }
        if (playerS.inDeath == true)
        {
            clickDeath.Play();
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

    public void StrobeLight()
    {
        if (holder.handInteraction == true)
        {
            if (!strobelight && flashlightOn)
            {
                strobelight = true;
            }
            else
            {
                strobelight = false;
            }
            Click();
        }
    }

    IEnumerator Strobing()
    {
        while (strobelight && batteryLife > 0 && flashlightOn)
        {
            yield return new WaitForSeconds(0.05f);
            light.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            light.SetActive(false);
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(Strobing());
    }
}
