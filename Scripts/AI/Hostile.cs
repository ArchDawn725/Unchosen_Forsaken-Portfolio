using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hostile : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject playerCamera;
    public Player playerS;
    public Hostile hostile;
    RaycastHit hit;
    public bool hitTarget;

    [Header("Senses")]
    public float sight; //if player is facing flashlight towards hostile
    public float sight2; //if player has lanturn on
    public float smell; //natural distance from player
    public float sence; //if player is right ontop of hostile
    public float hearing;     
    [Space(10)]
    public float fleeDist;
    public float fleeDistSet;
    public float attackDist;
    public float destinationDistance = 0.1f;
    [Space(20)]

    [Header("Creature Type")]
    public bool isShadow;
    public bool isShook;
    public bool isStalker;
    public bool isBaby;
    public bool isMother;
    public bool isSpider;
    public bool isHead;
    public bool isWatcher;
    public bool isEve;
    [Space(20)]

    [Header("Behaviors")]
    public bool hasSenced;
    public bool hasFleed;
    public bool attacking;
    public bool hasTargeted;
    [Space(10)]
    public bool isWalking;
    public bool isAttacking;
    public bool isIdle;
    [Space(20)]

    [Header("Animations")]
    public Animation referenceToAnimation;
    public AnimationClip[] clips;
    public int _currClip = 0;
    [Space(20)]

    [Header("Abilities")]
    public float speed;
    public float disapear;
    public bool babyCall;
    public int fleeTimer;
    [Space(20)]

    [Header("Disapearing Acts")]
    public Renderer rend;
    public Collider collider;
    public GameObject visuals;
    public GameObject visuals2;
    public GameObject visuals3;
    [Space(20)]

    [Header("Sounds")]
    public AudioSource idleNoise;
    public AudioSource aggroNoise;
    public AudioSource sencedNoise;
    public AudioSource movingNoise;
    [Space(10)]
    public AudioSource babyTouchNoise;
    public AudioSource babyAggro2Noise;
    [Space(20)]

    [Header("Patrols")]
    public float patroltime;
    public float setPatrolTime;
    public float nightTimePatrolTime;
    public GameObject[] patrolPoints;
    public float patrolRange;
    public int setPatrolNumber;
    public Transform setPatrol;
    [Space(20)]

    [Header("Other")]
    public Transform flashlight;
    public Transform launtern;
    public GameObject sound;
    public GameObject soundCreater;
    public GameObject Mother;
    public GameObject eveSpawner;

    void Start()
    {
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("Camera (head)");
        playerS = player.GetComponent("Player") as Player;

        patrolPoints = GameObject.FindGameObjectsWithTag("patrolPoints");
        _currClip = 0;
        referenceToAnimation.clip = clips[_currClip];
        referenceToAnimation.Play();
        StartCoroutine(Patrol());
        if (isStalker)
        {
            FindPatrolPoint();
        }

        if (isBaby)
        {
            Mother = GameObject.Find("Mother2(Clone)");
            hostile = Mother.GetComponent<Hostile>();
        }
        StartCoroutine(Hearing());
        idleNoise.enabled = true;
        aggroNoise.enabled = false;
        movingNoise.enabled = false;
        sencedNoise.enabled = false;
        if (isMother)
        {
            visuals.SetActive(false);
            collider.enabled = false;
        }
        if (isSpider)
        {
            Vector3 pos = transform.position;
            pos.y = 3f;
            transform.position = pos;
        }
        if (isEve)
        {
            StartCoroutine(InvisableMovement());
        }
    }

    void Update()
    {
        navMeshAgent.speed = speed;
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (playerS.lanternOn == true)
        {
            if (dist < sight2)
            {
                if (!hasSenced && !isShook)
                {
                    StartCoroutine(Senced());
                    hasSenced = true;
                }
                if (isShook)
                {
                    navMeshAgent.destination = launtern.position;
                }
            }
        }

        if (dist < smell)
        {
            if (!hasSenced)
            {
                StartCoroutine(Senced());
                hasSenced = true;
            }
        }

        if (dist < sence)
        {
            if (!hasSenced)
            {
                StartCoroutine(Senced());
                hasSenced = true;
            }
        }

        if (dist < attackDist)
        {
            _currClip = 3;
            referenceToAnimation.clip = clips[_currClip];
            referenceToAnimation.Play();
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if (dist > fleeDist)
        {
            if (!hasFleed)
            {
                StartCoroutine(Senced());
                hasFleed = true;
            }
        }

        if (isShadow == true)
        {
            if (playerS.hour >= 22 || playerS.hour < 6)
            {
                sence = 1000;
                fleeDistSet = 1001;

                if (disapear <= 0)
                {
                    aggroNoise.enabled = true;
                    collider.enabled = true;
                    rend.enabled = true;
                    speed = 3;
                }
                else
                {
                    idleNoise.enabled = false;
                    aggroNoise.enabled = false;
                    movingNoise.enabled = false;
                    sencedNoise.enabled = false;
                    rend.enabled = false;
                    speed = 0;
                    disapear--;
                }
            }
            else
            {
                rend.enabled = false;
                speed = 0;
                idleNoise.enabled = false;
                aggroNoise.enabled = false;
                movingNoise.enabled = false;
                sencedNoise.enabled = false;
                collider.enabled = false;
            }
        }

        if (hasTargeted)
        {
            navMeshAgent.destination = player.transform.position;
        }

        if (!attacking)
        {
            if (Vector3.Distance(navMeshAgent.destination, transform.position) > destinationDistance)
            {
                _currClip = 2;
                referenceToAnimation.clip = clips[_currClip];
                referenceToAnimation.Play();
                movingNoise.enabled = true;
            }
            else
            {
                _currClip = 0;
                referenceToAnimation.clip = clips[_currClip];
                referenceToAnimation.Play();
                movingNoise.enabled = false;
            }
        }

        if(isMother)
        {
            if (babyCall)
            {
                sence += 1000;
                fleeDistSet += 1000;
                collider.enabled = true;
                visuals.SetActive(true);
            }
            else
            {
                sence = 0;
                fleeDistSet = 0;
                collider.enabled = false;
                visuals.SetActive(false);
            }
        }

        if (playerS.inHome)
        {
            fleeDist = 0;
        }
        else
        {
            fleeDist = fleeDistSet;
        }

        if (Physics.Raycast(transform.position, playerCamera.transform.position - transform.position, out hit))
        {
            Debug.DrawLine(transform.position, hit.point);
            if (hit.collider.name == "Player")
            {
                hitTarget = true;
                if (isHead)
                {
                    if (playerS.isWalking == true)
                    {
                        if (dist < fleeDist)
                        {
                            navMeshAgent.destination = player.transform.position;
                        }
                    }
                }
            }
            else
            {
                hitTarget = false;
            }
        }
    }

    public void FlashlightOnMe()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < sight && !isStalker && !isShook)
        {
            StartCoroutine(Senced());
        }
        if (isShadow)
        {
            disapear += 2f;
        }
        if (isStalker)
        {
            visuals.SetActive(false);
            collider.enabled = false;
            speed = 0;
            fleeTimer = 50;
            StartCoroutine(Flee());
        }
        if (isShook)
        {
            navMeshAgent.destination = flashlight.position;
        }
        if (isSpider)
        {
            speed = 0;
            _currClip = 0;
            referenceToAnimation.clip = clips[_currClip];
            referenceToAnimation.Play();
            movingNoise.enabled = false;
        }
    }

    public void LightOnMe()
    {
        if (isShadow)
        {
            disapear += 2f;
        }
        if (isShook)
        {
            FindPatrolPoint();
        }
    }

    public void LookingAtMe()
    {
        if (isWatcher)
        {
            visuals.SetActive(false);
            visuals2.SetActive(false);
            visuals3.SetActive(false);
            collider.enabled = false;
            speed = 0;
            fleeTimer = 20;
            StartCoroutine(Flee());
        }
    }

    IEnumerator Senced()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        _currClip = 1;
        referenceToAnimation.clip = clips[_currClip];
        referenceToAnimation.Play();
        sencedNoise.enabled = true;
        idleNoise.enabled = false;
        yield return new WaitForSeconds(1f);
        if (dist < fleeDist)
        {
            hasFleed = false;
            hasTargeted = true;
            if (isShook)
            {
                Instantiate(soundCreater, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            aggroNoise.enabled = true;
            sencedNoise.enabled = false;
        }
        else
        {
            hasSenced = false;
            hasTargeted = false;
            sencedNoise.enabled = false;
            aggroNoise.enabled = false;
            idleNoise.enabled = true;
        }
    }

    IEnumerator Patrol()
    {
        while (!hasSenced)
        {
            if (playerS.hour < 22 || playerS.hour >= 6)
            {
                patroltime = setPatrolTime;
            }
            else
            {
                patroltime = nightTimePatrolTime;
            }
            yield return new WaitForSeconds(patroltime);
            patrolPoints = GameObject.FindGameObjectsWithTag("patrolPoints");
            FindPatrolPoint();
        }
        yield return new WaitForSeconds(patroltime);
        StartCoroutine(Patrol());
    }

    public void FindPatrolPoint()
    {
        setPatrolNumber = Random.Range(0, patrolPoints.Length);
        setPatrol = patrolPoints[setPatrolNumber].transform;

        float dist = Vector3.Distance(patrolPoints[setPatrolNumber].transform.position, transform.position);
        if (dist < patrolRange)
        {
            navMeshAgent.destination = patrolPoints[setPatrolNumber].transform.position;
        }

    }

    IEnumerator Flee()
    {
        navMeshAgent.destination = patrolPoints[setPatrolNumber].transform.position;
        sence = 0;
        if (isStalker)
        {
            speed = 3;
        }
        fleeDistSet = 0;
        yield return new WaitForSeconds(1f);
        if (fleeTimer > 0)
        {
            aggroNoise.enabled = false;
            fleeTimer--;
            StartCoroutine(Flee());
            visuals.SetActive(false);
            collider.enabled = false;
        }
        else
        {
            aggroNoise.enabled = true;
            speed = 0.5f;
            sence = 1000;
            fleeDistSet = 1000;
            visuals.SetActive(true);
            if (isWatcher)
            {
                visuals2.SetActive(true);
                visuals3.SetActive(true);
            }
            collider.enabled = true;

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isBaby)
            {
                hostile.babyCall = true;
                Instantiate(soundCreater, this.gameObject.transform.position, this.gameObject.transform.rotation);
                babyTouchNoise.enabled = true;
                babyAggro2Noise.enabled = true;
            }
        }
    }

    IEnumerator Hearing()
    {
        yield return new WaitForSeconds(2f);
        sound = GameObject.Find("Sound(Clone)");
        while (sound != null)
        {
            yield return new WaitForSeconds(2f);
            float dist = Vector3.Distance(sound.transform.position, transform.position);
            if (dist < hearing)
            {
                navMeshAgent.destination = sound.transform.position;
            }
            else
            {
                sound = null;
            }
            if (dist < 1)
            {
                sound = null;
            }
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(Hearing());
    }

    IEnumerator InvisableMovement()
    {
        navMeshAgent.destination = player.transform.position;
        yield return new WaitForSeconds(3f);
        speed = 2;
        rend.enabled = false;
        collider.enabled = false;

        yield return new WaitForSeconds(1f);
        speed = 0;
        rend.enabled = true;
        collider.enabled = true;

        StartCoroutine(InvisableMovement());
    }

    public void SleepReset()
    {
        navMeshAgent.destination = patrolPoints[setPatrolNumber].transform.position;
        babyCall = false;
        if (isEve)
        {
            Instantiate(eveSpawner, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}