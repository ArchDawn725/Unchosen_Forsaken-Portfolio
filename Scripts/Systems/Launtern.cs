using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launtern : MonoBehaviour
{
    public GameObject player;
    public Player playerS;
    public GameObject light;
    public bool lightOn;
    public float oilLevel;
    public Light launterLight;

    public float fireIntensity;
    public float fireAverage;
    public float fireMax;
    public float fireMin;
    public float fireDifferance;

    public bool isCandle;
    public bool inDeath;


    public float time { get; set; }
    public float duration = 1.0f;

    bool evaluating = true;

    public Gradient colourOverLifetime;

    public AnimationCurve intensityOverLifetime = new AnimationCurve(

        new Keyframe(0.0f, 0.0f),
        new Keyframe(0.5f, 1.0f),
        new Keyframe(1.0f, 0.0f));

    public bool loop = true;
    public bool autoDestruct = false;

    public Color startColour;

    public AudioSource igniteOffice;
    public AudioSource igniteBasement;
    public AudioSource igniteOutside;
    public AudioSource igniteDeath;

    public AudioSource blowoutOffice;
    public AudioSource blowoutBasement;
    public AudioSource blowoutOutside;
    public AudioSource blowoutDeath;

    public AudioSource fireOffice;
    public AudioSource fireBasement;
    public AudioSource fireOutside;
    //public float startIntensity;

    public AudioSource droppedOffice;
    public AudioSource droppedBasement;
    public AudioSource droppedOutside;
    public AudioSource droppedDeath;

    public GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Lantern");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        StartCoroutine(OilDrain());
        //StartCoroutine(Fire());
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;

        //LaunterSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        //launterLight.intensity = fireIntensity;

        fireAverage = oilLevel/4;
        fireMax = fireAverage * fireDifferance;
        fireMin = fireAverage / fireDifferance;
        flame.transform.localScale = new Vector3((oilLevel/10), (oilLevel / 10), (oilLevel / 10));

        if (evaluating)
        {
            if (time < duration)
            {
                time += Time.deltaTime;

                if (time > duration)
                {
                    if (autoDestruct)
                    {
                        Destroy(gameObject);
                    }
                    else if (loop)
                    {
                        time = 0.0f;
                    }
                    else
                    {
                        time = duration;
                        evaluating = false;
                    }
                }
            }

            if (time <= duration)
            {
                float normalizedTime = time / duration;

                launterLight.color = startColour * colourOverLifetime.Evaluate(normalizedTime);
                launterLight.intensity = fireAverage * intensityOverLifetime.Evaluate(normalizedTime);
            }
        }

        if (this.gameObject.transform.position.y < -100)
        {
            Destroy(this.gameObject);
        }
    }

    public void LaunterSwitch()
    {
        if (lightOn || inDeath)
        {
            light.SetActive(false);
            lightOn = false;
            playerS.lanternOn = false;
            flame.SetActive(false);
            ClickOff();
        }
        else
        {
            light.SetActive(true);
            lightOn = true;
            playerS.lanternOn = true;
            flame.SetActive(true);
            Click();
        }
    }

    IEnumerator OilDrain()
    {
        if (lightOn && oilLevel > 0)
        {
            yield return new WaitForSeconds(10f);
            if (!isCandle)
            {
                oilLevel -= 0.015f;
            }
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(OilDrain());
    }

    IEnumerator Fire()
    {
        while (lightOn)
        {
            yield return new WaitForSeconds(0.1f);
            fireIntensity = Random.Range(fireMin, fireMax);
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Fire());
    }

    public void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "Oil")
        {
            oilLevel += .25f;
            Destroy(other.gameObject);
        }
        */
        if (other.gameObject.tag == "Death")
        {
            inDeath = true;
            LaunterSwitch();
        }

        if (other.gameObject.layer == 0 || other.gameObject.layer == 3 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 23 || other.gameObject.layer == 24 || other.gameObject.layer == 30 || other.gameObject.layer == 31)//31 == floor
        {
            Dropped();
        }
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

    public void ClickOff()
    {
        if (playerS.inOffice == true)
        {
            blowoutOffice.Play();
        }
        if (playerS.inBasement == true)
        {
            blowoutBasement.Play();
        }
        if (playerS.inOutside == true)
        {
            blowoutOutside.Play();
        }
        if (playerS.inDeath == true)
        {
            blowoutDeath.Play();
        }
        fireOffice.enabled = false;
        fireOutside.enabled = false;
        fireBasement.enabled = false;
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

/*



            // ...


            // =================================	
            // Functions.
            // =================================

            // ...

            void Awake()
            {
                light = GetComponent<Light>();
            }

            // ...

            void Start()
            {
                startColour = light.color;
                startIntensity = light.intensity;

                light.color = startColour * colourOverLifetime.Evaluate(0.0f);
                light.intensity = startIntensity * intensityOverLifetime.Evaluate(0.0f);
            }

            // ...

            void OnEnable()
            {

            }
            void OnDisable()
            {
                // Reset for next OnEnable if required.

                light.color = startColour;
                light.intensity = startIntensity;

                time = 0.0f;
                evaluating = true;

                light.color = startColour * colourOverLifetime.Evaluate(0.0f);
                light.intensity = startIntensity * intensityOverLifetime.Evaluate(0.0f);
            }
*/