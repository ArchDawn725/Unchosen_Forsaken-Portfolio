using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicConverter : MonoBehaviour
{
    public bool overLimit;
    public float limit = 100;
    public GameObject sound;
    public float loudness;

    public void Start()
    {
        StartCoroutine(LimitReseter());
    }

    public void Update()
    {
        if (loudness > limit)
        {
            overLimit = true; 
            print("Shouting");
        }
    }

    private IEnumerator LimitReseter()
    {
        yield return new WaitForSeconds(1);
        if (overLimit)
        {
            Instantiate(sound, this.gameObject.transform.position, this.gameObject.transform.rotation);
            overLimit = false;
        }
        StartCoroutine(LimitReseter());
    }
}
