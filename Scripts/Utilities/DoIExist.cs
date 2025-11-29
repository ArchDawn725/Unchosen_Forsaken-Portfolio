using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoIExist : MonoBehaviour
{
    public float exsistanceChance = 50;
    public float LuckyNumber;

    public bool hasStarted = false;
    public bool hasStarted2 = false;

    public bool special;
    public Renderer off;

    public Light light;
    private float number;

    // Start is called before the first frame update
    void Start()
    {
        if (hasStarted && hasStarted2 == false)
        {
            LuckyNumber = Random.Range(0, 100);
            if (LuckyNumber > exsistanceChance)
            {
                if (special)
                {
                    off.enabled = true;
                }
                Destroy(this.gameObject);
            }
            hasStarted2 = true;

        }
        else
        {
            hasStarted = true;
        }

        light = GetComponent<Light>();
        if (light != null)
        {
            number = light.intensity;
            light.intensity = number / 4;
        }
        else
        {
            light = GetComponentInChildren<Light>();
            if (light != null)
            {
                number = light.intensity;
                light.intensity = number / 3;
            }
        }
    }
}
