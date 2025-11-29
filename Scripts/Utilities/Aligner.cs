using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aligner : MonoBehaviour
{
    public bool aligned;
    public GameObject nodes;

    public GameObject basement;
    public BasementController controller;

    public bool isPower;

    public GameObject[] objects;

    public void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
        if (isPower)
        {
            basement = GameObject.Find("Basement");
            controller = basement.GetComponent("BasementController") as BasementController;
            controller.powerRooms++;
        }
        if (aligned)
        {
            Invoke("Delay", 0.5f);
        }
        StartCoroutine(Rotate());
    }

    public void OnTriggerEnter(Collider other)
    {
        aligned = true;
        Invoke("Delay", 0.5f);
        //Destroy(this);
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(0.2f);

        if (!aligned)
        {
            this.gameObject.transform.Rotate(0, 90, 0);
            StartCoroutine(Rotate());
        }
    }

    public void Delay()
    {
        nodes.SetActive(true);
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }
}
