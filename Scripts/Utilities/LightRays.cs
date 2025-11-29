using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRays : MonoBehaviour
{
    public LayerMask hostileLayer;
    public Hostile2 hostile;

    public Vector3 test;
    public Vector3 test2;
    public Vector3 test3;
    public Vector3 test4;
    public Vector3 test5;
    public float lightDistance;

    public void Update()
    {
        Vector3 ray1 = transform.TransformDirection(test) * lightDistance;
        Vector3 ray2 = transform.TransformDirection(test2) * lightDistance;
        Vector3 ray3 = transform.TransformDirection(test3) * lightDistance;
        Vector3 ray4 = transform.TransformDirection(test4) * lightDistance;
        Vector3 ray5 = transform.TransformDirection(test5) * lightDistance;
        Debug.DrawRay(transform.position, ray1, Color.green);
        Debug.DrawRay(transform.position, ray2, Color.red);
        Debug.DrawRay(transform.position, ray3, Color.green);
        Debug.DrawRay(transform.position, ray4, Color.red);
        Debug.DrawRay(transform.position, ray5, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, ray1, out hit, Mathf.Infinity, hostileLayer))
        {
            if (hit.collider.GetComponent<Hostile2>() != null)
            {
                hostile = hit.collider.GetComponent<Hostile2>();
                hostile.LightOnMe();
            }
        }

        if (Physics.Raycast(transform.position, ray2, out hit, Mathf.Infinity, hostileLayer))
        {
            if (hit.collider.GetComponent<Hostile2>() != null)
            {
                hostile = hit.collider.GetComponent<Hostile2>();
                hostile.LightOnMe();
            }
        }

        if (Physics.Raycast(transform.position, ray3, out hit, Mathf.Infinity, hostileLayer))
        {
            if (hit.collider.GetComponent<Hostile2>() != null)
            {
                hostile = hit.collider.GetComponent<Hostile2>();
                hostile.LightOnMe();
            }
        }

        if (Physics.Raycast(transform.position, ray4, out hit, Mathf.Infinity, hostileLayer))
        {
            if (hit.collider.GetComponent<Hostile2>() != null)
            {
                hostile = hit.collider.GetComponent<Hostile2>();
                hostile.LightOnMe();
            }
        }

        if (Physics.Raycast(transform.position, ray5, out hit, Mathf.Infinity, hostileLayer))
        {
            if (hit.collider.GetComponent<Hostile2>() != null)
            {
                hostile = hit.collider.GetComponent<Hostile2>();
                hostile.LightOnMe();
            }
        }
    }
}
