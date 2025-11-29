using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 oldEulerAngles;
    public float medium;

    public GameObject soundCreater;
    public AudioSource squeak;

    public bool hasPlayed;
    public float luckyNumber;
    public float soundChance;

    public float test;

    void Start()
    {
        Invoke("GetAngles", 10);
    }

    public void GetAngles()
    {
        oldEulerAngles.y = this.gameObject.transform.rotation.eulerAngles.y;
        StartCoroutine(Tracker());
    }

    IEnumerator Tracker()
    {
        yield return new WaitForSeconds(2f);
        if (hasPlayed)
        {
            oldEulerAngles.y = this.gameObject.transform.rotation.eulerAngles.y;
            hasPlayed = false;
        }
        medium = oldEulerAngles.y - this.gameObject.transform.rotation.eulerAngles.y;
        if (medium > 10 | medium < -10)
        {
            luckyNumber = Random.Range(0, 100);
            if (soundChance > luckyNumber)
            {
                Instantiate(soundCreater, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            squeak.enabled = true;
            hasPlayed = true;
            StartCoroutine(Tracker());
        }
        else
        {
            squeak.enabled = false;
            StartCoroutine(Tracker());
        }

    }

    public void  Update()
    {
        //test = GetComponent<Rigidbody>().velocity.magnitude;
        //print(test);// audioClipSpeed;
        //audio.pitch = Mathf.Clamp(p, 0.1, 4.0); // p is clamped to sane values
        //print(medium);
    }
}
