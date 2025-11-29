using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public bool isHeld;
    public GameObject holdster;

    public bool handInteraction;

    void FixedUpdate()
    {
        if (isHeld && !handInteraction)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.position = holdster.transform.position;
            gameObject.transform.rotation = holdster.transform.rotation;
            this.gameObject.transform.SetParent(holdster.transform);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.transform.SetParent(null);
        }
    }

    public void HandInteractionOn()
    {
        handInteraction = true;
    }

    public void HandInteractionOff()
    {
        handInteraction = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Start")
        {
            Destroy(this.gameObject);
        }
    }
}
