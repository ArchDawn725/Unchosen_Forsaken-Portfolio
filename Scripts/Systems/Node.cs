using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject basement;
    public BasementController controller;

    public float waitMin;
    public float WaitMax;
    public float waitTime;

    public enum BasementType
    {
        corridor,
        hallway
    }
    [SerializeField] private BasementType basementType;

    public GameObject[] corridorItems;
    public GameObject[] hallwayItems;

    void Start()
    {
        basement = GameObject.Find("Basement");
        controller = basement.GetComponent("BasementController") as BasementController;
        waitTime = Random.Range(waitMin, WaitMax);
        if (basementType == BasementType.hallway)
        {
            waitTime = waitTime * 2;
        }
        Invoke("Delay", waitTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    public void Delay()
    {
        if (basementType == BasementType.corridor)
        {
            int Zone1Index = Random.Range(0, corridorItems.Length);
            Instantiate(corridorItems[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
        if (basementType == BasementType.hallway)
        {
            int Zone1Index = Random.Range(0, hallwayItems.Length);
            Instantiate(hallwayItems[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
