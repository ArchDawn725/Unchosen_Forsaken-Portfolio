using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingChecker : MonoBehaviour
{
    public float distance;
    public Vector3 test;

    public GameObject sound;
    public GameObject effect;

    public bool hitting;

    public RainController con;

    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ray1 = transform.TransformDirection(test) * distance;

        Debug.DrawRay(transform.position, ray1, Color.green);

        RaycastHit hit;



        if (Physics.Raycast(transform.position, ray1, out hit, Mathf.Infinity, layer))
        {
            //print(hit.collider.name);
            //sound.SetActive(false);
            //effect.SetActive(false);
            hitting = true;
            con.active = false;
        }
        else
        {
            //sound.SetActive(true);
            //effect.SetActive(true);
            hitting = false;
            con.active = true;
        }
    }
}
