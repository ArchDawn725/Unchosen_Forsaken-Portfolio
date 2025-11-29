using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public Light[] light;
    public Light bright;
    public AudioSource sound;

    public float WaitOffTimeMax;
    public float WaitOffTimeMin;

    public float WaitOnTimeMax;
    public float WaitOnTimeMin;

    public bool isCLight;
    public LightRays lightRays;

    public Renderer on;
    public Renderer off;

    public GameObject player;
    public Player playerS;

    public float offWait;
    public float onWait;

    private float number;

    void Awake()
    {
        bright = GetComponent<Light>();
        number = bright.intensity;
        //bright.intensity = number / 4;
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        if (playerS.hour < 3)
        {
            onWait = (Random.Range(WaitOnTimeMin, WaitOnTimeMax)) * 0.4f;
            offWait = (Random.Range(WaitOffTimeMin, WaitOffTimeMax));
        }
        else
        {
            onWait = (Random.Range(WaitOnTimeMin, WaitOnTimeMax));
            offWait = (Random.Range(WaitOffTimeMin, WaitOffTimeMax)) * 0.25f;
        }

        yield return new WaitForSeconds(onWait);
        foreach (Light light in light)
        {
            light.enabled = false;
            if (isCLight)
            {
                lightRays.enabled = false;
            }
        }
        on.enabled = false;
        off.enabled = true;
        sound.enabled = false;

        yield return new WaitForSeconds(offWait);
        foreach (Light light in light)
        {
            light.enabled = true;
            if (isCLight)
            {
                lightRays.enabled = true;
            }
        }
        on.enabled = true;
        off.enabled = false;
        sound.enabled = true;
        StartCoroutine(Flashing());
    }
}
