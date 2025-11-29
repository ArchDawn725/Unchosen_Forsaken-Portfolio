using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementItem : MonoBehaviour
{
    public GameObject basement;
    public BasementController controller;

    public bool cannotOpen;

    public enum BasementType
    {
        corridor,
        hallway,
        room,
        powerRoom,
        blockage
    }
    [SerializeField] private BasementType basementType;

    public bool found;
    public GameObject[] nodes;

    public GameObject corridorBlockage;
    public GameObject hallwayBlockage;

    public GameObject parent;

    public Collider collider1;
    public Collider collider2;

    void Start()
    {
        basement = GameObject.Find("Basement");
        controller = basement.GetComponent("BasementController") as BasementController;
        if (basementType == BasementType.powerRoom)
        {
            controller.powerRooms++;
        }
        Invoke("StartRoutine", 1f);
    }
    public void StartRoutine()
    {
        collider1.enabled = true;
        collider2.enabled = true;
        if (!found)
        {
            StartCoroutine(Rotate());
        }
        else
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].SetActive(true);
            }
        }
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(0.1f);

        while (!found)
        {
            yield return new WaitForSeconds(0.1f);
            if (!found)
            {
                parent.transform.Rotate(0, 90, 0);
            }

        }

        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i].SetActive(true);
        }

        //Destroy(this);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basement")
        {
            found = true;
        }
    }




    /*
    // Start is called before the first frame update
    void Start()
    {
        basement = GameObject.Find("Basement");
        controller = basement.GetComponent("BasementController") as BasementController;
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1);
        while (!found)
        {
            yield return new WaitForSeconds(1);
            transform.Rotate(0, 90, 0);
        }

        if (basementType == BasementType.hallway)
        {
            if (controller.hallways >= controller.hallwaysMax && controller.powerRooms != 0)
            {
                Instantiate(hallwayBlockage, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this);
            }
        }

        if (basementType == BasementType.room)
        {
            if (controller.rooms >= controller.roomsMax)
            {
                Instantiate(hallwayBlockage, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this);
            }
        }

        if (basementType == BasementType.powerRoom)
        {
            if (controller.powerRooms >= controller.powerRoomsMax)
            {
                Instantiate(hallwayBlockage, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this);
            }
        }

        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i].SetActive(true);
        }

        Destroy(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basement")
        {
            found = true;
        }
    }
    */
}
