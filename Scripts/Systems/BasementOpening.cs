using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementOpening : MonoBehaviour
{
    public BasementItem basement;
    public GameObject location;
    public GameObject basementOpening;
    public BasementItem basement2;

    public GameObject basementController;
    public BasementController controller;

    public void OnTriggerStay(Collider other)
    {
        basementController = GameObject.Find("Basement");
        controller = basementController.GetComponent("BasementController") as BasementController;

        if (controller.timeOver == false)
        {
            if (other.gameObject.tag == "Basement")
            {
                basement = other.GetComponent<BasementItem>();
                if (basement.cannotOpen == false)
                {
                    if (basement.found == true && basement2.found == true)
                    {
                        Instantiate(basementOpening, location.transform.position, location.transform.rotation);
                        Destroy(this);
                    }
                }
            }
        }
    }
}
