using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSpawner : MonoBehaviour
{
    public int luckyNumber;
    public int spawnNothingCNumber = 0;
    public int oldFlashlightNumber = 40;
    public int utilityFlashlightNumber = 70;
    public int magLightNumber = 90;
    public int theTorchNumber = 100;

    public GameObject oldFlashLight;
    public GameObject utilityLight;
    public GameObject magLight;
    public GameObject theTorch;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("KeySpawn", 1);
    }

    public void KeySpawn()
    {
        luckyNumber = Random.Range(0, 100);

        if (luckyNumber > spawnNothingCNumber && luckyNumber < oldFlashlightNumber)
        {
            Instantiate(oldFlashLight, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (luckyNumber > oldFlashlightNumber && luckyNumber < utilityFlashlightNumber)
        {
            Instantiate(utilityLight, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (luckyNumber > utilityFlashlightNumber && luckyNumber < magLightNumber)
        {
            Instantiate(magLight, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (luckyNumber > magLightNumber && luckyNumber < theTorchNumber)
        {
            Instantiate(theTorch, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
