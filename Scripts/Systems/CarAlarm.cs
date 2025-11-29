using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAlarm : MonoBehaviour
{
    public Light[] light;
    public AudioSource sound;

    public float waitTime;

    public float exsistanceChance = 50;
    public float LuckyNumber;

    public GameObject effect;

    void Awake()
    {
        LuckyNumber = Random.Range(0, 100);
        if (LuckyNumber > exsistanceChance)
        {
            Destroy(this);
        }

        //Light = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        yield return new WaitForSeconds(waitTime);
        foreach (Light light in light)
        {
            light.enabled = false;
            effect.SetActive(false);
            sound.enabled = false;
        }
        sound.enabled = false;
        yield return new WaitForSeconds(waitTime);
        foreach (Light light in light)
        {
            light.enabled = true;
            effect.SetActive(true);
            sound.enabled = true;
        }
        StartCoroutine(Flashing());
    }
}
