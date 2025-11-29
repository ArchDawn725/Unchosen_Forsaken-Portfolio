using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour
{
    public LayerMask hostileLayer;

    public bool isFlashlight;
    public bool isEyes;
    public bool isSpotLight;

    public Flashlight light;
    public SightRadar sight;
    public Hostile2 hostile;
    public DeathAni death;
    public Boss boss;
    public float lightDistance;

    public Vector3 angle;
    public bool saw;

    public int number;
    public bool hitBoss;

    public enum rayNumb
    {
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine
    }

    [SerializeField] private rayNumb raynumb;

    // Start is called before the first frame update
    void Start()
    {
        if (isFlashlight)
        {
            lightDistance = light.lightDistance;
        }
        if (isEyes)
        {
            lightDistance = sight.lightDistance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashlight && light.flashlightOn == true)
        {
            Vector3 ray = transform.TransformDirection(angle) * lightDistance;

            Debug.DrawRay(transform.position, ray, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, ray, out hit, Mathf.Infinity, hostileLayer))
            {
                light.seenHostile = true;
                saw = true;
                if (hit.collider.GetComponent<Hostile2>() != null)
                {
                    hostile = hit.collider.GetComponent<Hostile2>();
                    hostile.flashlight = this.gameObject.transform;
                    hostile.flashlightS = light;
                    hostile.FlashlightOnMe();
                }
            }
            else
            {
                saw = false;
            }
        }
        else if (isFlashlight)
        {
            saw = false;
        }

        if (isEyes)
        {
            Vector3 ray = transform.TransformDirection(angle) * lightDistance;

            Debug.DrawRay(transform.position, ray, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, ray, out hit, Mathf.Infinity, hostileLayer))
            {
                sight.seenHostile = true;
                saw = true;
                if (hit.collider.GetComponent<Hostile2>() != null)
                {
                    hostile = hit.collider.GetComponent<Hostile2>();
                    hostile.sightRadar = sight;
                    hostile.LookingAtMe();
                }
                if (hit.collider.GetComponent<DeathAni>() != null)
                {
                    death = hit.collider.GetComponent<DeathAni>();
                    death.LookingAtMe();
                }
            }
            else
            {
                saw = false;
            }
        }

        if (isSpotLight)
        {
            Vector3 ray = transform.TransformDirection(angle) * lightDistance;

            Debug.DrawRay(transform.position, ray, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, ray, out hit, Mathf.Infinity, hostileLayer))
            {

                if (hit.collider.GetComponent<Boss>() != null)
                {
                    boss = hit.collider.GetComponent<Boss>();
                    if (!hitBoss)
                    {
                        boss.hits++;
                        boss.Hit();
                        hitBoss = true;
                    }
                }
            }
        }

        if (isFlashlight)
        {
            if (raynumb == rayNumb.one)
            {
                if (saw)
                {
                    light.saw1 = true;
                }
                else
                {
                    light.saw1 = false;
                }
            }

            if (raynumb == rayNumb.two)
            {
                if (saw)
                {
                    light.saw2 = true;
                }
                else
                {
                    light.saw2 = false;
                }
            }

            if (raynumb == rayNumb.three)
            {
                if (saw)
                {
                    light.saw3 = true;
                }
                else
                {
                    light.saw3 = false;
                }
            }

            if (raynumb == rayNumb.four)
            {
                if (saw)
                {
                    light.saw4 = true;
                }
                else
                {
                    light.saw4 = false;
                }
            }

            if (raynumb == rayNumb.five)
            {
                if (saw)
                {
                    light.saw5 = true;
                }
                else
                {
                    light.saw5 = false;
                }
            }

            if (raynumb == rayNumb.six)
            {
                if (saw)
                {
                    light.saw6 = true;
                }
                else
                {
                    light.saw6 = false;
                }
            }

            if (raynumb == rayNumb.seven)
            {
                if (saw)
                {
                    light.saw7 = true;
                }
                else
                {
                    light.saw7 = false;
                }
            }

            if (raynumb == rayNumb.eight)
            {
                if (saw)
                {
                    light.saw8 = true;
                }
                else
                {
                    light.saw8 = false;
                }
            }

            if (raynumb == rayNumb.nine)
            {
                if (saw)
                {
                    light.saw9 = true;
                }
                else
                {
                    light.saw9 = false;
                }
            }
        }
    }
}
