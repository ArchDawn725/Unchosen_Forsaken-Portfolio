using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using Autohand.Demo;

public class Player : MonoBehaviour
{
    public int hour;
    public int minute;
    public string minuteText;
    public TextMeshPro timerText;

    public bool lanternOn;
    public XRNode inputSource;
    private Vector2 inputAxis;

    public AudioSource walkingOffice;
    public AudioSource walkingBasement;
    public AudioSource walkingOutside;
    public AudioSource walkingOnWater;
    public AudioSource walkingOnGrass;
    public AudioSource walkingInStart;
    public AudioSource alarm;

    public Hostile2 hostileS;

    public bool inHome;
    public bool isWalking;
    public bool isRunning;
    public bool isCurrentlyWalking;

    public GameObject PatrolPoint;

    public float speed = 1.5f;
    public Common2DAxis moverAxis;

    public float watchSpeed;

    public bool sprinting;
    public float energy;
    public float maxEnergy = 10;
    public float currentSpeed;

    public GameObject spritBar;
    public GameObject runningOffice;
    public GameObject runningBasement;
    public GameObject runningOutside;

    public GameObject runningWater;
    public GameObject runningGrass;
    public GameObject runningInStart;

    public int introNumber;
    public int secondFloorNumber;
    public int basementNumber;
    public int outsideNumber;

    public bool leverPulled;

    public GameObject camera;

    public bool isPoisoned;
    public float poison;
    public float currentMaxEnergy;
    public GameObject poisonBar;

    public bool onWater;
    public bool onGrass;

    public enum Floor
    {
        start,
        intro,
        second,
        basement,
        outside,
        death
    }

    public Floor floor;

    public bool inStart;
    public bool inOffice;
    public bool inBasement;
    public bool inOutside;
    public bool inDeath;

    public GameObject loadingDecal;

    public float speedPotion;

    public int choosenLevel;

    public GameObject cameraLoc;
    public GameObject offSetLoc;
    public Vector3 local;
    public Vector3 local2;
    public Vector3 local3;

    public GameObject reseter;
    public float speedVar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        RenderSettings.fog = true;

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        //StartCoroutine(Foggy());
        StartCoroutine(WatchTimer());
        StartCoroutine(Senced());
        StartCoroutine(Fatigue());
        StartCoroutine(Poisoned());
        StartCoroutine(Walker());
    }

    // Update is called once per frame
    void Update()
    {
        Center();//test
        spritBar.transform.localScale = new Vector3(1, 1, (energy / 10));
        poisonBar.transform.localScale = new Vector3(1, 1, -(poison / 10));
        if (minute < 10)
        {
            minuteText = ("0" + minute.ToString());
        }
        else
        {
            minuteText = (minute.ToString());
        }
        timerText.text = (hour.ToString() + ":" + minuteText);

        /*
        if (hour >= 20 || hour < 8)
        {
            RenderSettings.fog = true;
        }
        else
        {
            RenderSettings.fog = false;
        }
        */
        if (isWalking && isCurrentlyWalking && !isRunning && speed >0 && currentSpeed > 0)
        {
            if (floor == Floor.start || floor == Floor.intro)
            {
                walkingInStart.enabled = true;
            }
            else if (floor == Floor.second)
            {
                     walkingOffice.enabled = true;
            }
            else if (floor == Floor.basement)
            {
                if (!onWater)
                {
                    walkingBasement.enabled = true;
                    walkingOnWater.enabled = false;
                }
                else
                {
                    walkingOnWater.enabled = true;
                    walkingBasement.enabled = false;
                }
            }
            else if (floor == Floor.outside)
            {
                if (!onGrass)
                {
                    walkingOutside.enabled = true;
                    walkingOnGrass.enabled = false;
                }
                else
                {
                    walkingOnGrass.enabled = true;
                    walkingOutside.enabled = false;
                }
            }
        }
        else
        {
            walkingOffice.enabled = false;
            walkingBasement.enabled = false;
            walkingOutside.enabled = false;
            walkingOnWater.enabled = false;
            walkingOnGrass.enabled = false;
            walkingInStart.enabled = false;
        }

        if (isRunning && speed > 0 && currentSpeed > 0)
        {
            if (floor == Floor.start || floor == Floor.intro)
            {
                runningInStart.SetActive(true);
            }
            else if (floor == Floor.second)
            {
                runningOffice.SetActive(true);
            }
            else if (floor == Floor.basement)
            {
                if (!onWater)
                {
                    runningBasement.SetActive(true);
                    runningWater.SetActive(false);
                }
                else
                {
                    runningWater.SetActive(true);
                    runningBasement.SetActive(false);
                }
            }
            else if (floor == Floor.outside)
            {
                if (!onGrass)
                {
                    runningOutside.SetActive(true);
                    runningGrass.SetActive(false);
                }
                else
                {
                    runningGrass.SetActive(true);
                    runningOutside.SetActive(false);
                }
            }
        }
        else
        {
            runningOffice.SetActive(false);
            runningBasement.SetActive(false);
            runningOutside.SetActive(false);

            runningInStart.SetActive(false);
            runningWater.SetActive(false);
            runningGrass.SetActive(false);
        }
        /*
        bool triggerValue;
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out triggerValue) && triggerValue)
        {
            Debug.Log("sprint button is pressed.");
            speed = 3;
        }
        else
        {
            speed = 2;
        }
        */

        //this.gameObject.transform.position = this.gameObject.transform.position - camera.transform.position;
    }

    IEnumerator WatchTimer()
    {
        /*
        while(timer>-9999999)
        {
            yield return new WaitForSeconds(1f);
            timer--;
        }
        */
        if (hour < 4)
        {
            timerText.color = Color.red;
            //alarm.enabled = true;
        }
        else
        {
            timerText.color = Color.white;
            //alarm.enabled = false;
        }

        yield return new WaitForSeconds(watchSpeed);
        if (floor == Floor.second)
        {
            inOffice = true;
            inBasement = false;
            inOutside = false;
            inDeath = false;
            inStart = false;
            if (minute == 59)
            {
                hour++;
                minute = 0;
            }
            else
            {
                minute++;
            }
            if (hour == 24)
            {
                hour = 0;
                minute = 0;
            }

        }
        if (floor == Floor.basement)
        {
            inOffice = false;
            inBasement = true;
            inOutside = false;
            inDeath = false;
            inStart = false;
            if (leverPulled)
            {
                if (minute == 0)
                {
                    hour--;
                    minute = 59;
                }
                else
                {
                    minute--;
                }
            }
            else
            {
                if (minute == 59)
                {
                    hour++;
                    minute = 0;
                }
                else
                {
                    minute++;
                }
            }
        }
        if (floor == Floor.outside)
        {
            yield return new WaitForSeconds(watchSpeed*3);
            inOffice = false;
            inBasement = false;
            inOutside = true;
            inDeath = false;
            inStart = false;
            if (minute == 0)
            {
                hour--;
                minute = 59;
            }
            else
            {
                minute--;
            }
        }
        if (floor == Floor.intro || floor == Floor.start)
        {
            inOffice = false;
            inBasement = false;
            inOutside = true;
            inDeath = false;
            inStart = false;
            hour = 0;
            minute = 0;
        }

        StartCoroutine(WatchTimer());
    }

    IEnumerator Foggy()
    {
        while (hour < 4)
        {
            yield return new WaitForSeconds(1f);
           // RenderSettings.fog = true;
            RenderSettings.fogDensity += 0.001f;
        }
        yield return new WaitForSeconds(1f);
       // RenderSettings.fog = false;
        StartCoroutine(Foggy());

    }

    public void OnStartOver()
    {
        currentSpeed = 1.5f;
        //SceneManager.LoadScene(0);
        loadingDecal.SetActive(true);
        Instantiate(reseter, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject, 0.1f);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Home")
        {
            inHome = true;

            if (floor == Floor.second)
            {
                currentSpeed = 1.4f;
            }
            if (floor == Floor.basement)
            {
                currentSpeed = 1.6f;
            }
            if (floor == Floor.outside)
            {
                currentSpeed = 1.8f;
            }
        }
        if (other.gameObject.tag == "Hostile")
        {
            print("ive been hit");
            hostileS = other.GetComponent<Hostile2>();
            if (hostileS.disapear > 0)
            {
                print("I Am not Dead");
            }
            else
            {
                print("I Am Dead");
                //OnStartOver();
                OnDeathScene();
            }
        }

        if (other.gameObject.tag == "DeathAni")
        {
            OnStartOver();
        }

        if (other.gameObject.tag == "Death")
        {
            currentSpeed= 0;
            floor = Floor.death;
            inOffice = false;
            inBasement = false;
            inOutside = false;
            inDeath = true;
            inStart = false;
        }

        if (other.gameObject.tag == "Start")
        {
            currentSpeed = 1.5f;
            inStart = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Home")
        {
            inHome = false;
        }
    }

    IEnumerator Senced()
    {
        yield return new WaitForSeconds(10f);
        if (!inHome)
        {
            if (isWalking)
            {
                Instantiate(PatrolPoint, gameObject.transform.position, gameObject.transform.rotation);
            }
        }
    }

    IEnumerator Walker()
    {
        yield return new WaitForSeconds(1f);
        if (!isCurrentlyWalking)
        {
            isWalking = false;
        }
        StartCoroutine(Walker());
    }

    IEnumerator Fatigue()
    {
        while (sprinting)
        {
            yield return new WaitForSeconds(0.05f);
            if (energy > 0)
            {
                isRunning = true;
                if (speedPotion > 0)
                {
                    if (speedVar < 1.75f)
                    {
                        speedVar += 0.25f;
                    }
                    speed = currentSpeed * speedVar;
                }
                else
                {
                    if (speedVar < 1.5f)
                    {
                        speedVar += 0.1f;
                    }
                    speed = currentSpeed * speedVar;
                }

                energy -= 0.1f;
            }
            else
            {
                isRunning = false;
                speed = currentSpeed;
            }
        }
        yield return new WaitForSeconds(0.1f);
        isRunning = false;
        if (energy < currentMaxEnergy)
        {
            energy += 0.1f;
        }
        if (speedPotion > 0)
        {
            speedVar = 1.25f;
            speed = currentSpeed * speedVar;
        }
        else
        {
            speedVar = 1;
            speed = currentSpeed * speedVar;
        }

        StartCoroutine(Fatigue());
    }

    public void OnDeathScene()
    {
        print("on DeathScene");
        loadingDecal.SetActive(true);
        if (hostileS.isShadow)
        {
            SceneManager.LoadSceneAsync("ShadowDeath");
        }
        if (hostileS.isShook)
        {
            SceneManager.LoadSceneAsync("ShookDeath");
        }
        if (hostileS.isStalker)
        {
            SceneManager.LoadSceneAsync("StalkerDeath");
        }
        if (hostileS.isMother)
        {
            SceneManager.LoadSceneAsync("MotherDeath");
        }
        if (hostileS.isSpider)
        {
            SceneManager.LoadSceneAsync("SpiderDeath");
        }
        if (hostileS.isHead)
        {
            SceneManager.LoadSceneAsync("HeadDeath");
        }
        if (hostileS.isWatcher)
        {
            SceneManager.LoadSceneAsync("WatcherDeath");
        }
        if (hostileS.isEve)
        {
            SceneManager.LoadSceneAsync("EveDeath");
        }

        if (hostileS.isHandicap)
        {
            SceneManager.LoadSceneAsync("ExperimentalDeath");
        }
        if (hostileS.isBrute)
        {
            if (hostileS.notActive == false)
            {
                SceneManager.LoadSceneAsync("BruteDeath");
            }
            else
            {
                loadingDecal.SetActive(false);
            }
        }
        if (hostileS.isLurker)
        {
            SceneManager.LoadSceneAsync("LurkerDeath");
        }
        if (hostileS.isSkeleton)
        {
            if (hostileS.notActive == false)
            {
                SceneManager.LoadSceneAsync("SkeletonDeath");
            }
            else
            {
                loadingDecal.SetActive(false);
            }
        }
        if (hostileS.isUndying)
        {
            SceneManager.LoadSceneAsync("UndyingDeath");
        }

        if (hostileS.isCat)
        {
            SceneManager.LoadSceneAsync("CatDeath");
        }
        if (hostileS.isAdmirer)
        {
            SceneManager.LoadSceneAsync("AdmirerDeath");
        }
        if (hostileS.isSkook)
        {
            SceneManager.LoadSceneAsync("SkookDeath");
        }
        if (hostileS.isMutant)
        {
            SceneManager.LoadSceneAsync("MutantDeath");
        }
        if (hostileS.isAnger)
        {
            SceneManager.LoadSceneAsync("AngerDeath");
        }
        if (hostileS.isHusk)
        {
            SceneManager.LoadSceneAsync("HuskDeath");
        }
        if (hostileS.isReaper)
        {
            SceneManager.LoadSceneAsync("ReaperDeath");
        }
        if (hostileS.isHideoplast)
        {
            SceneManager.LoadSceneAsync("HideoplastDeath");
        }
    }

    public void SecondFloorChoice()
    {
        loadingDecal.SetActive(true);
        choosenLevel = 1;
        floor = Floor.intro;
        SceneManager.LoadSceneAsync("Intro" + introNumber);
    }

    public void BasementChoice()
    {
        loadingDecal.SetActive(true);
        choosenLevel = 2;
        floor = Floor.intro;
        SceneManager.LoadSceneAsync("Intro" + introNumber);
    }

    public void OutsideChoice()
    {
        loadingDecal.SetActive(true);
        choosenLevel = 3;
        floor = Floor.intro;
        SceneManager.LoadSceneAsync("Intro" + introNumber);
    }

    public void EndChoice()
    {
        loadingDecal.SetActive(true);
        choosenLevel = 4;
        floor = Floor.intro;
        SceneManager.LoadSceneAsync("Intro" + introNumber);
    }

    public void IntroTeleport()
    {
        loadingDecal.SetActive(true);
        floor = Floor.intro;
        SceneManager.LoadSceneAsync("Intro" + introNumber);
    }

    public void SecondFloorTeleport()
    {
        if (floor == Floor.intro)
        {
            loadingDecal.SetActive(true);
            choosenLevel = 1;
            floor = Floor.second;
            SceneManager.LoadSceneAsync("secondFloor" + secondFloorNumber);
        }
    }

    public void BasementTeleport()
    {
        if (floor == Floor.intro || floor == Floor.outside || floor == Floor.second)
        {
            loadingDecal.SetActive(true);
            choosenLevel = 2;
            floor = Floor.basement;
            hour = 4;
            minute = 0;
            SceneManager.LoadSceneAsync("basement" + basementNumber);
        }
    }

    public void OutsideTeleport()
    {
        if (floor == Floor.intro || floor == Floor.basement)
        {
            loadingDecal.SetActive(true);
            choosenLevel = 3;
            floor = Floor.outside;
            hour = 23;
            minute = 59;
            SceneManager.LoadSceneAsync("outside" + outsideNumber);
        }
    }

    public void EndTeleport()
    {
        loadingDecal.SetActive(true);
        choosenLevel = 4;
        floor = Floor.intro;
        hour = 0;
        minute = -1000;
        PlayerPrefs.SetInt("levelsWon", 3);
        SceneManager.LoadSceneAsync("EndScene");
    }

    public void CreditsTeleport()
    {
        loadingDecal.SetActive(true);
        choosenLevel = 5;
        PlayerPrefs.SetInt("levelsWon", 4);
        SceneManager.LoadSceneAsync("Credits");
    }

    IEnumerator Poisoned()
    {
        yield return new WaitForSeconds(0.1f);
        if (isPoisoned)
        {
            poison += 0.05f;
            currentMaxEnergy -= 0.05f;
            if (poison > maxEnergy)
            {
                isPoisoned = false;
                loadingDecal.SetActive(true);
                SceneManager.LoadSceneAsync("LeechDeath");
            }
            else
            {
                loadingDecal.SetActive(false);
            }
        }
        else
        {
            if (poison > 0.1f)
            {
                poison -= 0.05f;
                currentMaxEnergy += 0.05f;
            }
            else
            {
                currentMaxEnergy = maxEnergy;
            }
        }


        StartCoroutine(Poisoned());

    }

    IEnumerator SpeedPotion()
    {
        while (speedPotion > 0)
        {
            speedPotion--;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(SpeedPotion());
    }

    public void Center()
    {
        //XRInputSubsystem.TryRecenter();
        //local = cameraLoc.transform.position;
        //local3 = -cameraLoc.transform.position;
        //local3 = local2 - local;
        //offSetLoc.transform.position = local3;
    }

    public void Disable()
    {
        loadingDecal.SetActive(false);
    }
}

