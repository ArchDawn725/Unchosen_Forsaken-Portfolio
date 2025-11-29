using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementNode : MonoBehaviour
{
    public GameObject basement;
    public BasementController controller;

    public enum BasementType
    {
        corridorUp,
        corridorDown,
        corridorRight,
        corridorLeft,
        hallway
    }
    [SerializeField] private BasementType basementType;

    public GameObject[] corridorItemsUp;
    public GameObject[] corridorItemsDown;
    public GameObject[] corridorItemsRight;
    public GameObject[] corridorItemsLeft;
    public GameObject[] hallwayItems;
    public GameObject corridorBlockage;
    public GameObject hallwayBlockage;

    public Collider collider;


    void Start()
    {
        collider.enabled = true;
        basement = GameObject.Find("Basement");
        controller = basement.GetComponent("BasementController") as BasementController;
        if (controller.timeOver == true)
        {
            Destroy(this.gameObject);
        }
        if (basementType == BasementType.hallway)
        {
            StartCoroutine(Timer());
        }
        else
        {
            Invoke("DelayedStart", 0.1f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

    public void DelayedStart()
    {
        if (controller.corridors < controller.corridorsMax)
        {
            if (basementType == BasementType.corridorUp)
            {
                controller.corridors++;
                int Zone1Index = Random.Range(0, corridorItemsUp.Length);
                Instantiate(corridorItemsUp[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            if (basementType == BasementType.corridorDown)
            {
                controller.corridors++;
                int Zone1Index = Random.Range(0, corridorItemsDown.Length);
                Instantiate(corridorItemsDown[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            if (basementType == BasementType.corridorRight)
            {
                controller.corridors++;
                int Zone1Index = Random.Range(0, corridorItemsRight.Length);
                Instantiate(corridorItemsRight[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            if (basementType == BasementType.corridorLeft)
            {
                controller.corridors++;
                int Zone1Index = Random.Range(0, corridorItemsLeft.Length);
                Instantiate(corridorItemsLeft[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            if (basementType == BasementType.hallway)
            {
                if (controller.powerRooms == 0)
                {
                    controller.corridors++;
                    int Zone1Index = Random.Range(0, hallwayItems.Length);
                    Instantiate(hallwayItems[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                    Destroy(this.gameObject);
                }
                else
                {
                    controller.corridors++;
                    int Zone1Index = Random.Range(0, (hallwayItems.Length - 1));
                    Instantiate(hallwayItems[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                    Destroy(this.gameObject);
                }
            }

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        if (controller.timed == true)
        {
            Invoke("DelayedStart", 0.1f);
        }
        else
        {
            StartCoroutine(Timer());
        }
    }




    /*
    // Start is called before the first frame update
    void Start()
    {
        collider.enabled = true;
        basement = GameObject.Find("Basement");
        controller = basement.GetComponent("BasementController") as BasementController;

        if (basementType == BasementType.corridor)
        {
            if (controller.corridors < controller.corridorsMax)
            {
                controller.corridors++;
                int Zone1Index = Random.Range(0, corridorItems.Length);
                Instantiate(corridorItems[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(corridorBlockage, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
        }

        if (basementType == BasementType.hallway)
        {
            int Zone1Index = Random.Range(0, corridorItems.Length);
            Instantiate(corridorItems[Zone1Index], this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basement")
        {
            if (basementType == BasementType.corridor)
            {
                //Instantiate(corridorBlockage, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }

            if (basementType == BasementType.hallway)
            {
                //Instantiate(hallwayBlockage, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
    */
}
