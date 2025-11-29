using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Hostile2 : MonoBehaviour
{
    public enum Behaviour
    {
        idle,
        walking,
        targeted,
        chasing,
        inActive
    }
    public enum Creature
    {
        isShadow,
        isShook,
        isStalker,
        isBaby,
        isMother,
        isSpider,
        isHead,
        isWatcher,
        isEve,
        isHandicap,
        isBrute,
        isLurker,
        isLeech,
        isSkeleton,
        isUndying,
        isCat,
        isAdmirer,
        isSkook,
        isMutant,
        isAnger,
        isHusk,
        isReaper,
        IsHideoplast
    }

    public bool gameStarted = true;
    [Space(10)]
    [SerializeField] private Behaviour behaviour;
    public Creature creature;
    [Space(20)]
    public GameObject player;
    public Player playerS;
    public NavMeshAgent navMeshAgent;
    [SerializeField] private Transform targetedObject;
    public bool hasTargeted = false;
    public float reactivity = 0.5f;
    public float destinationDistance = 0.1f;
    public float fleeDist = 100;
    public float speed;
    public float triggerChance;
    public float LuckyNumber;
    private float actualTriggerChance;
    [Space(20)]

    [Header("Senses")]
    public bool doesPatrol = true;
    public float patrolTimer = 10;
    public GameObject marker;
    [Space(10)]
    public bool canSence;
    public float sence; //if player is right ontop of hostile
    [Space(10)]
    public bool CanSee_Lantern;
    public float sight_Lantern; //if player has lanturn on
    public GameObject lantern;
    [Space(10)]
    public bool flashLightReactive;
    public float sight_Flashlight; //if player is facing flashlight towards hostile
    public Transform flashlight;
    [Space(10)]
    public bool dayTimeReactive;
    public bool canDisapear;
    public float disapear;
    [Space(10)]
    public bool canHear;
    public float hearing;
    public GameObject sound;
    [Space(10)]
    public bool canSee_Movement;
    public float sight_Movement;
    public Transform perspective;
    [Space(10)]
    public bool reactiveToBeingScene;
    public bool touchReactive;
    [Space(10)]
    public bool powerSwitchReactive;
    [Space(10)]
    public bool fireReactiveFear;
    public bool fireReactiveHate;
    public bool flashlightHate;
    public bool flashlightAwaken;
    [Space(20)]

    [Header("Disapearing Acts")]
    public bool canFlicker;
    public Collider collider;
    public Renderer rend;
    public Renderer rend2;
    public GameObject visuals;
    public GameObject visuals2;
    public GameObject visuals3;
    [Space(20)]

    [Header("Animations")]
    public bool isStatic = false;
    public Animation referenceToAnimation;
    public AnimationClip[] clips;
    [Space(20)]

    [Header("Sounds")]
    public GameObject soundCreater;
    public AudioSource idleNoise;
    public AudioSource aggroNoise;
    public AudioSource sencedNoise;
    public AudioSource movingNoise;
    [Space(10)]
    public AudioSource babyTouchNoise;
    public AudioSource babyAggro2Noise;

    [Header("Special")]
    public GameObject eveSpawner;
    [SerializeField] private bool babyCall;
    private Hostile2 hostile;
    private GameObject mother;
    private GameObject baby;
    RaycastHit hit;
    [HideInInspector] public Flashlight flashlightS;
    [SerializeField] private bool hitTarget;
    public bool notActive;

    public Vector3 loc;

    public bool pathAvailable;
    public NavMeshPath navMeshPath;
    public float chaseResponceTime = 1;

    public PointTest pointT;
    public HeartSensor sensor;
    public GameObject playerCamera;
    public bool nightTimeAggro;

    public bool cannotLook;
    public AimConstraint aimConstraint;
    public bool returnToMarker;
    [HideInInspector] public SightRadar sightRadar;

    public AudioSource howl;

    public bool canFly;
    public float maxHeight;
    public float minHeight;

    public bool insideHusk;

    public int priority = 8;
    public bool lanternInSight;
    public GameObject fire;
    public Fire fireS;
    public Vector3 home;
    public bool returnHome;
    public bool canSenceAtNightTime;

    public void Start()
    {
        if (gameStarted)
        {
            Starting();
            Invoke("StartRoutine", 1);
            home = this.gameObject.transform.position;
            marker.transform.position = home;
        }
    }

    public void Starting()
    {
        sight_Lantern += 3;
        triggerChance += 10000;
        navMeshPath = new NavMeshPath();
        navMeshAgent.speed = speed;
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        playerCamera = GameObject.Find("PlayerPerspective");
        if (CanSee_Lantern)
        {
            lantern = GameObject.Find("Lantern");
        }

        if (creature == Creature.isSpider)
        {
            Vector3 pos = transform.position;
            pos.y = 3f;
            transform.position = pos;
            navMeshAgent.enabled = false;
            navMeshAgent.enabled = true;
        }
        if (creature == Creature.isBaby)
        {
            mother = GameObject.Find("Mother2(Clone)");
            hostile = mother.GetComponent<Hostile2>();
            hostile.baby = this.gameObject;
        }
        if (creature == Creature.isAdmirer)
        {
            this.gameObject.transform.LookAt(player.transform);
        }
        actualTriggerChance = triggerChance * reactivity;
        howl.enabled = true;
    }

    public void StartRoutine()
    {
        StartCoroutine(Controller());
        if (!isStatic)
        {
            StartCoroutine(Animations());
        }
        else
        {
            StartCoroutine(Animations());
            referenceToAnimation.clip = clips[0];
            referenceToAnimation.Play();
        }
        if (doesPatrol)
        {
            StartCoroutine(Patrol());
        }
        if (canSence)
        {
            StartCoroutine(Sence());
            if (flashlightAwaken || creature == Creature.isAnger || canSenceAtNightTime)
            {
                canSence = false;
            }
        }
        if (CanSee_Lantern)
        {
            StartCoroutine(Sight_Lantern());
        }
        if (dayTimeReactive)
        {
            StartCoroutine(DayTimeReactive());
        }
        if (canDisapear)
        {
            StartCoroutine(Disapear());
        }
        if (canFlicker)
        {
            StartCoroutine(InvisableMovement());
        }
        if (canSee_Movement)
        {
            StartCoroutine(SightByMovement());
        }
        if (creature == Creature.isMother)
        {
            StartCoroutine(Mother());
        }
        if (canHear)
        {
           // StartCoroutine(Hearing());
        }
        if (flashLightReactive)
        {
            StartCoroutine(SawLight());
        }
        if (powerSwitchReactive)
        {
            //StartCoroutine(powerSwitch());
        }
        if (canFly)
        {
            StartCoroutine(Flying());
        }

        //fire mechanic
        //navMeshAgent.ResetPath();
        if (creature != Creature.isSkeleton || creature != Creature.isBrute)
        {
            targetedObject = marker.transform;
            priority = 8;
        }
    }

    IEnumerator Animations()
    {
        yield return new WaitForSeconds(reactivity/2);

        if (behaviour == Behaviour.idle)
        {
            idleNoise.enabled = true;
            movingNoise.enabled = false;
            sencedNoise.enabled = false;
            aggroNoise.enabled = false;
            if (!isStatic)
            {
                referenceToAnimation.clip = clips[(int)behaviour];
                referenceToAnimation.Play();
            }
            if (!cannotLook)
            {
                aimConstraint.enabled = false;
            }
            if (insideHusk)
            {
                this.gameObject.transform.rotation = Quaternion.Inverse(marker.transform.rotation);
            }
        }

        if (behaviour == Behaviour.walking)
        {
            idleNoise.enabled = true;
            movingNoise.enabled = true;
            sencedNoise.enabled = false;
            aggroNoise.enabled = false;
            if (!isStatic)
            {
                referenceToAnimation.clip = clips[(int)behaviour];
                referenceToAnimation.Play();
            }
            if (!cannotLook)
            {
                aimConstraint.enabled = false;
            }
            navMeshAgent.speed = speed/2;
        }

        if (behaviour == Behaviour.targeted)
        {
            idleNoise.enabled = false;
            movingNoise.enabled = false;
            sencedNoise.enabled = true;
            aggroNoise.enabled = false;
            if (!isStatic)
            {
                referenceToAnimation.clip = clips[(int)behaviour];
                referenceToAnimation.Play();
            }
            if (!cannotLook)
            {
                aimConstraint.enabled = true;
            }
        }

        if (behaviour == Behaviour.chasing)
        {
            idleNoise.enabled = false;
            if (isMutant || isBrute || isAnger)
            {

            }
            else
            {
                movingNoise.enabled = true;
            }
            sencedNoise.enabled = false;
            aggroNoise.enabled = true;
            if (!isStatic)
            {
                referenceToAnimation.clip = clips[(int)behaviour];
                referenceToAnimation.Play();
            }
            if (creature == Creature.isHandicap)
            {
                Instantiate(soundCreater, player.transform.position, player.transform.rotation);
            }
            if (!cannotLook)
            {
                aimConstraint.enabled = true;
            }
        }

        if (behaviour == Behaviour.inActive)
        {
            idleNoise.enabled = false;
            movingNoise.enabled = false;
            sencedNoise.enabled = false;
            aggroNoise.enabled = false;
            if (!isStatic)
            {
                referenceToAnimation.clip = clips[(int)behaviour];
                referenceToAnimation.Play();
            }
            if (!cannotLook)
            {
                aimConstraint.enabled = false;
            }
        }

        StartCoroutine(Animations());
    }

    IEnumerator Controller()
    {
        yield return new WaitForSeconds(reactivity / 2);

        if (behaviour == Behaviour.inActive) { }
        else { 
            if (priority == 1)
            {
                hasTargeted = false;
                marker.transform.position = home;

                if (creature == Creature.isMutant || creature == Creature.isBrute)
                {
                    canSence = false;
                }

                if (Vector3.Distance(navMeshAgent.destination, transform.position) > destinationDistance)
                {
                    behaviour = Behaviour.walking;
                }
                else
                {
                    priority = 8;
                }
            }

            if (priority == 2)
            {
                if (sound != null && Vector3.Distance(sound.transform.position, transform.position) < hearing && canHear && Vector3.Distance(navMeshAgent.destination, transform.position) > destinationDistance)
                {
                    hasTargeted = true;
                    marker.transform.position = sound.transform.position;

                    if (behaviour != Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                        behaviour = Behaviour.chasing;
                    }
                    if (creature != Creature.isEve)
                    {
                        navMeshAgent.speed = speed;
                    }

                    if (CalculateNewPath() == true)
                    {
                        pathAvailable = true;
                       // navMeshAgent.destination = targetedObject.position;
                    }
                    else
                    {
                        pathAvailable = false;
                        if (creature != Creature.isBaby)
                        {
                           // priority = 1;
                        }
                    }
                }
                else
                {
                    if (behaviour == Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                    }
                    priority = 3;
                }
            }

            if (priority == 3)
            {
                if (fireReactiveHate && fire != null && fireS.burntOut == false)
                {
                    hasTargeted = true;
                    if (behaviour != Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                        behaviour = Behaviour.chasing;
                    }
                    if (creature != Creature.isEve)
                    {
                        navMeshAgent.speed = speed;
                    }

                    marker.transform.position = fire.transform.position;

                    if (CalculateNewPath() == true)
                    {
                        pathAvailable = true;
                        //navMeshAgent.destination = targetedObject.position;
                    }
                    else
                    {
                        pathAvailable = false;
                        if (creature != Creature.isBaby)
                        {
                            //priority = 1;
                        }
                    }
                }
                else
                {
                    if (behaviour == Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                    }
                    priority = 4;
                }
            }

            if (priority == 4)
            {
                if (flashlightHate && flashlight != null && Vector3.Distance(flashlight.position, transform.position) < sight_Flashlight && flashlightS.flashlightOn == true)
                {

                    if (behaviour != Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                        behaviour = Behaviour.chasing;
                        hasTargeted = true;
                    }
                    if (creature != Creature.isEve)
                    {
                        navMeshAgent.speed = speed;
                    }

                    marker.transform.position = flashlight.position;

                    if (CalculateNewPath() == true)
                    {
                        pathAvailable = true;
                        //navMeshAgent.destination = targetedObject.position;
                    }
                    else if (Vector3.Distance(flashlight.position, transform.position) > sight_Flashlight)
                    {
                        pathAvailable = false;
                        if (creature != Creature.isBaby)
                        {
                            print("path unavailable");
                            priority = 1;
                        }
                    }
                }
                else
                {
                    if (behaviour == Behaviour.chasing)
                    {
                        if (flashlight != null && flashlightS.flashlightOn == false)
                        {
                            flashlight = null;
                        }
                    }
                    priority = 5;
                }
            }

            if (priority == 5)
            {
                if (CanSee_Lantern && lanternInSight && Vector3.Distance(lantern.transform.position, transform.position) < sight_Lantern && playerS.lanternOn == true && lantern != null)
                {
                    hasTargeted = true;
                    if (behaviour != Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                        behaviour = Behaviour.chasing;
                    }
                    if (creature != Creature.isEve)
                    {
                        navMeshAgent.speed = speed;
                    }

                    marker.transform.position = lantern.transform.position;

                    if (CalculateNewPath() == true)
                    {
                        pathAvailable = true;
                        //navMeshAgent.destination = targetedObject.position;
                    }
                    else if (Vector3.Distance(lantern.transform.position, transform.position) > sight_Lantern)
                    {
                        pathAvailable = false;
                        if (creature != Creature.isBaby)
                        {
                            priority = 1;
                        }
                    }
                }
                else
                {
                    if (behaviour == Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                    }
                    priority = 6;
                }
            }

            if (priority == 6)
            {
                if (playerS.isWalking == true && canSee_Movement && hitTarget == true)
                {
                    hasTargeted = true;
                    if (behaviour != Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                        behaviour = Behaviour.chasing;
                    }
                    if (creature != Creature.isEve)
                    {
                        navMeshAgent.speed = speed;
                    }

                    marker.transform.position = player.transform.position;

                    if (CalculateNewPath() == true)
                    {
                        pathAvailable = true;
                        //navMeshAgent.destination = targetedObject.position;
                    }
                    else
                    {
                        pathAvailable = false;
                        if (creature != Creature.isBaby)
                        {
                            //priority = 1;
                        }
                    }
                }
                else
                {
                    if (behaviour == Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                    }
                    priority = 7;
                }
            }

            if (priority == 7)
            {
                if (canSence && Vector3.Distance(player.transform.position, transform.position) < sence)
                {
                    navMeshAgent.CalculatePath(player.transform.position, navMeshPath);
                    if (navMeshPath.status == NavMeshPathStatus.PathComplete)
                    {
                        if (CalculateNewPath() == true)
                        {
                            pathAvailable = true;
                            //navMeshAgent.destination = targetedObject.position;
                            //break
                            hasTargeted = false;
                            if (behaviour != Behaviour.chasing)
                            {
                                behaviour = Behaviour.targeted;
                                navMeshAgent.speed = 0;
                                yield return new WaitForSeconds(chaseResponceTime);
                                behaviour = Behaviour.chasing;
                            }
                            if (creature != Creature.isEve)
                            {
                                navMeshAgent.speed = speed;
                            }

                            marker.transform.position = player.transform.position;
                        }



                    }
                    else// if (Vector3.Distance(player.transform.position, transform.position) > sence)
                    {
                        pathAvailable = false;
                        if (creature != Creature.isBaby)
                        {
                            priority = 1;
                        }
                    }
                }
                else
                {
                    if (behaviour == Behaviour.chasing)
                    {
                        behaviour = Behaviour.targeted;
                        navMeshAgent.speed = 0;
                        yield return new WaitForSeconds(chaseResponceTime);
                    }
                    priority = 8;
                }
            }

            if (priority == 8)
            {
                if (doesPatrol || insideHusk)
                {
                    hasTargeted = false;
                    targetedObject = marker.transform;
                    if (insideHusk)
                    {
                        marker.transform.position = home;
                    }

                    if (Vector3.Distance(navMeshAgent.destination, transform.position) > destinationDistance)
                    {
                        behaviour = Behaviour.walking;
                    }
                    else
                    {
                        behaviour = Behaviour.idle;
                    }
                }
                else
                {
                    behaviour = Behaviour.idle;
                }
            }
        }

        if (!notActive && hasTargeted == false && isBaby == false)
        {

            navMeshAgent.CalculatePath(marker.transform.position, navMeshPath);
            if (navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                targetedObject.position = marker.transform.position;
                navMeshAgent.destination = targetedObject.position;
            }

        }
        else if (hasTargeted)
        {
            targetedObject.position = marker.transform.position;
            navMeshAgent.destination = targetedObject.position;
        }

        StartCoroutine(Controller());
    }

    IEnumerator Sence()
    {
        yield return new WaitForSeconds(reactivity);

        if (canSence) //|| nightTimeAggro)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < sence)
            {
                LuckyNumber = Random.Range(0, 100);
                if (LuckyNumber < actualTriggerChance)
                {
                    if (priority > 7)
                    {
                        priority = 7;
                    }
                }
            }
        }
        
        StartCoroutine(Sence());
    }

    IEnumerator Sight_Lantern()
    {
        yield return new WaitForSeconds(reactivity);

        if (lantern != null)
        {
            if (Physics.Raycast(perspective.position, lantern.transform.position - perspective.position, out hit, sight_Lantern, playerLayer))
            {
                Debug.DrawLine(perspective.position, hit.point);
                if (playerS.lanternOn == true)
                {
                    if (hit.collider.name == "Lantern" || hit.collider.name == "Backpack" || hit.collider.name == "Holdster")
                    {
                        lanternInSight = true;
                        if (Vector3.Distance(lantern.transform.position, transform.position) < sight_Lantern)
                        {
                            LuckyNumber = Random.Range(0, 100);
                            if (LuckyNumber < actualTriggerChance)
                            {
                                if (priority > 5)
                                {
                                    priority = 5;
                                }
                            }
                        }
                    }
                    else
                    {
                        lanternInSight = false;
                    }
                }
            }

            StartCoroutine(Sight_Lantern());
        }
       
    }

    IEnumerator DayTimeReactive()
    {
        yield return new WaitForSeconds(reactivity);

        if (playerS.hour < 3)
        {
            patrolTimer = 5;
            nightTimeAggro = true;
            actualTriggerChance = (triggerChance * reactivity * 2);

            if (canSenceAtNightTime || flashLightReactive)
            {
                canSence = true;
            }
        }
        else
        {
            patrolTimer = 10;
            if (canDisapear)
            {
                disapear = 2;
            }
            nightTimeAggro = false;
            actualTriggerChance = triggerChance * reactivity;

            if (canSenceAtNightTime)
            {
                canSence = false;
            }
        }

        StartCoroutine(DayTimeReactive());
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(patrolTimer * 3);
        if (hasTargeted == false)
        {
            Vector3 point;
            if (RandomPoint(transform.position, fleeDist, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                marker.transform.position = point;
            }
        }

        StartCoroutine(Patrol());
    }

    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(reactivity);

        if (disapear <= 0)
        {
            if (behaviour == Behaviour.inActive)
            {
                behaviour = Behaviour.idle;
            }
            canSence = true;
            collider.enabled = true;
            navMeshAgent.speed = speed;
            if (rend != null)
            {
                rend.enabled = true;
            }
            if (creature == Creature.isWatcher)
            {
                visuals.SetActive(true);
                visuals2.SetActive(true);
                visuals3.SetActive(true);
            }
            if (creature == Creature.isMother || creature == Creature.isStalker || creature == Creature.isLurker)
            {
                visuals.SetActive(true);
            }
        }
        else
        {
            canSence = false;
            behaviour = Behaviour.inActive;
            if (creature != Creature.isAdmirer)
            {
                navMeshAgent.speed = 0;
            }

            if (rend != null)
            {
                rend.enabled = false;
            }
            if (creature == Creature.isWatcher)
            {
                visuals.SetActive(false);
                visuals2.SetActive(false);
                visuals3.SetActive(false);
            }
            if (creature == Creature.isMother || creature == Creature.isStalker || creature == Creature.isLurker)
            {
                visuals.SetActive(false);
            }

            disapear -= reactivity;
        }

        StartCoroutine(Disapear());
    }

    IEnumerator InvisableMovement()
    {
        if (creature == Creature.isEve)
        {
            yield return new WaitForSeconds(reactivity * 3);
            navMeshAgent.speed = speed;
            rend.enabled = false;
            collider.enabled = false;

            yield return new WaitForSeconds(reactivity);
            navMeshAgent.speed = 0;
            yield return new WaitForSeconds(reactivity);
            rend.enabled = true;
            collider.enabled = true;

            StartCoroutine(InvisableMovement());
        }

        if (creature == Creature.isAdmirer)
        {
            if (Vector3.Distance(navMeshAgent.destination, transform.position) > destinationDistance)
            {
                disapear = 1;
            }
            else
            {
                
              // rend.enabled = true;
               //collider.enabled = true;
              // rend2.enabled = true;
            }
        }

    }

    IEnumerator SightByMovement()
    {
        yield return new WaitForSeconds(reactivity);
        reactivity = 0.2f;
        if (Physics.Raycast(perspective.position, playerCamera.transform.position - perspective.position, out hit, sight_Movement, playerLayer))
        {
            Debug.DrawLine(perspective.position, hit.point);

            if (hit.collider.name == "Player")
            {
                hitTarget = true;
                if (playerS.isWalking == true)
                {
                    if (Vector3.Distance(player.transform.position, transform.position) < sight_Movement)
                    {
                        LuckyNumber = Random.Range(0, 100);
                        if (LuckyNumber < actualTriggerChance)
                        {
                            if (priority > 6)
                            {
                                priority = 6;
                            }
                        }

                    }
                }
            }
            else
            {
                hitTarget = false;
            }
        }
        StartCoroutine(SightByMovement());
    }

    IEnumerator Mother()
    {
        yield return new WaitForSeconds(reactivity*10);

        //babyCall = true;
        if (babyCall)
        {
            priority = 7;
        }
        else
        {
            disapear = 10;
        }

        StartCoroutine(Mother());
    }

    IEnumerator Hearing()
    {
        yield return new WaitForSeconds(reactivity);
        sound = GameObject.Find("Sound(Clone)");
        if (sound != null)
        {
            if (Vector3.Distance(sound.transform.position, transform.position) < hearing)
            {
                LuckyNumber = Random.Range(0, 100);
                if (LuckyNumber < actualTriggerChance)
                {
                    if (priority > 2)
                    {
                        priority = 2;
                    }
                }
            }
        }

        StartCoroutine(Hearing());
    }

    bool RandomPoint(Vector3 center, float fleeDist, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * (fleeDist / 2);
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    public void FlashlightOnMe()
    {
        if (flashLightReactive)
        {
            if (flashlightHate)
            {
                if (Vector3.Distance(flashlight.position, transform.position) < sight_Flashlight)
                {
                    if (flashlightS.LuckyNumber < triggerChance)
                    {
                        if (flashlightS.strobelight == true)
                        {
                            if (priority > 1)
                            {
                                priority = 1;
                            }
                        }
                        else
                        {
                            if (priority > 4)
                            {
                                priority = 4;
                            }
                        }

                    }
                }
            }
            if (creature == Creature.isShadow)
            {
                if (flashlightS.strobelight == true)
                {
                    disapear = 0.5f;
                }
                else
                {
                    disapear = 1;
                }
            }
            if (creature == Creature.isLurker)
            {
                if (flashlightS.strobelight == true)
                {
                    disapear = 1;
                }
                else
                {
                    disapear = 2;
                }
            }
            if (creature == Creature.isStalker)
            {
                if (flashlightS.strobelight == true)
                {
                    disapear = 25;
                }
                else
                {
                    disapear = 50;
                }
            }
            if (creature == Creature.isSpider)
            {
                targetedObject = null;
                navMeshAgent.ResetPath();
                behaviour = Behaviour.idle;
            }
            if (flashlightAwaken)
            {
                if (flashlightS.LuckyNumber < triggerChance)
                {
                    if (flashlightS.strobelight == true)
                    {
                        canSence = true;
                        notActive = false;
                        if (priority > 7)
                        {
                            priority = 7;
                        }
                    }
                    else
                    {
                        canSence = true;
                        notActive = false;
                        if (priority > 7)
                        {
                            priority = 7;
                        }
                    }
                }
            }
        }
    }

    IEnumerator SawLight()
    {
        yield return new WaitForSeconds(reactivity);
        if (flashlightS != null)
        {
            if (flashlightS.flashlightOn == true)
            {
                if (Vector3.Distance(flashlight.position, transform.position) < sight_Flashlight)
                {
                    LuckyNumber = Random.Range(0, 100);
                    if (LuckyNumber < actualTriggerChance)
                    {
                        if (priority > 4)
                        {
                            priority = 4;
                        }
                    }
                }
            }
        }

        StartCoroutine(SawLight());
    }



    public void LightOnMe()
    {
        if (flashLightReactive)
        {
            if (canDisapear)
            {
                disapear = 1;
            }
        }
    }

    public void LookingAtMe()
    {
        if (reactiveToBeingScene)
        {
            if (creature == Creature.isWatcher)
            {
                disapear = 25;
            }
            if (creature == Creature.isLurker)
            {
                disapear = 2;
            }

            if (creature == Creature.isAnger)
            {
                if (sightRadar.LuckyNumber < triggerChance)
                {
                    canSence = true;
                    if (priority > 7)
                    {
                        priority = 7;
                    }
                }

            }

            if (creature == Creature.isAdmirer)
            {
                this.gameObject.transform.LookAt(player.transform);
                pointT.Patrol();
                disapear = 5;
            }
        }
    }

    public void SleepReset()
    {
        priority = 1;

        babyCall = false;
        disapear += 10;
        if (creature == Creature.isEve)
        {
            Instantiate(eveSpawner, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //needs imrovement
        if (other.gameObject.tag == "Player")
        {
            if (touchReactive)
            {
                if (creature == Creature.isBaby)
                {
                    babyTouchNoise.enabled = true;
                }
                if (creature == Creature.isLeech)
                {
                    playerS.isPoisoned = true;
                }

            }
        }

        if (other.gameObject.tag == "Fire")
        {
            fire = other.gameObject;
            fireS = fire.GetComponent("Fire") as Fire;

            if (fireReactiveFear)
            {
                priority = 1;

                if (creature == Creature.isLeech)
                {
                    targetedObject = null;
                    navMeshAgent.ResetPath();
                    behaviour = Behaviour.idle;
                }
            }
            if (fireReactiveHate)
            {
                if (priority > 3)
                {
                    priority = 3;
                }
            }
        }

        /*
        if (other.gameObject.tag == "HeartBeat")
        {
            sensor = other.GetComponent<HeartSensor>();
            if (disapear > 0)
            {
                sensor.hostiles--;
            }
        }
        */
    }

    public void OnTriggerExit(Collider other)
    {
        //needs imrovement
        if (other.gameObject.tag == "Player")
        {
            if (touchReactive)
            {
                hostile.babyCall = true;
                Instantiate(soundCreater, this.gameObject.transform.position, this.gameObject.transform.rotation);
                babyTouchNoise.enabled = false;
                babyAggro2Noise.enabled = true;
            }
        }
    }

    IEnumerator powerSwitch()
    {
        yield return new WaitForSeconds(reactivity);
        if (playerS.choosenLevel == 2)
        {
            if (playerS.leverPulled == true)
            {
                LuckyNumber = Random.Range(0, 100);
                if (LuckyNumber < actualTriggerChance)
                {
                    canSence = true;
                    notActive = false;
                    if (priority > 7)
                    {
                        priority = 7;
                    }
                }
            }

            StartCoroutine(powerSwitch());
        }
    }

    IEnumerator Flying()
    {
        yield return new WaitForSeconds(reactivity/5);
        if (Vector3.Distance(player.transform.position, transform.position) < sence)
        {
            if (navMeshAgent.baseOffset > minHeight && hasTargeted)
            {
                navMeshAgent.baseOffset -= 0.01f;
            }
        }
        else if (navMeshAgent.baseOffset < maxHeight)
        {
            navMeshAgent.baseOffset += 0.01f;
        }

        StartCoroutine(Flying());
    }


    public bool isShadow;
    public bool isShook;
    public bool isStalker;
    public bool isBaby;
    public bool isMother;
    public bool isSpider;
    public bool isHead;
    public bool isWatcher;
    public bool isEve;
    public bool isHandicap;
    public bool isBrute;
    public bool isLurker;
    public bool isLeech;
    public bool isSkeleton;
    public bool isUndying;
    public bool isCat;
    public bool isAdmirer;
    public bool isSkook;
    public bool isMutant;
    public bool isAnger;
    public bool isHusk;
    public bool isReaper;
    public bool isHideoplast;

    public LayerMask playerLayer;

    bool CalculateNewPath()
    {
        navMeshAgent.CalculatePath(marker.transform.position, navMeshPath);
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
