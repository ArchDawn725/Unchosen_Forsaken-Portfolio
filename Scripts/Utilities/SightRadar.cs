using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightRadar : MonoBehaviour
{
    public LayerMask hostileLayer;

    public Hostile2 hostile;
    public DeathAni death;
    public Vector3 test;
    public float lightDistance;

    public Vector3 loc;
    public GameObject follower;
    public GameObject marker;

    public bool seenHostile;
    public float LuckyNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomNumber());
        //StartCoroutine(Controller());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ray1 = transform.TransformDirection(test) * lightDistance;

        Debug.DrawRay(transform.position, ray1, Color.green);


        RaycastHit hit;

        if (Physics.Raycast(transform.position, ray1, out hit, Mathf.Infinity, hostileLayer))
        {
            seenHostile = true;
            if (hit.collider.GetComponent<Hostile2>() != null)
            {
                hostile = hit.collider.GetComponent<Hostile2>();
                hostile.sightRadar = this;
                hostile.LookingAtMe();
            }
            if (hit.collider.GetComponent<DeathAni>() != null)
            {
                death= hit.collider.GetComponent<DeathAni>();
                death.LookingAtMe();
            }
        }
        else
        {
            seenHostile = false;
        }
    }

    IEnumerator Controller()
    {
        yield return new WaitForSeconds(1);
        marker = GameObject.Find("PlayerMarker(Clone)");
        Destroy(marker);
        Instantiate(follower, this.gameObject.transform.position, this.gameObject.transform.rotation);
        StartCoroutine(Controller());
    }

    IEnumerator RandomNumber()
    {
        while (seenHostile)
        {
            yield return new WaitForSeconds(1);
            LuckyNumber = Random.Range(0, 100);
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(RandomNumber());
    }
}
