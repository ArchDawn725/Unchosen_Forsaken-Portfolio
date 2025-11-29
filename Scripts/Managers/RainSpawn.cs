using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawn : MonoBehaviour
{
    public RainController con;

    public GameObject player;
    public float dist;

    public int myNumber;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(RainCheck());
    }

    IEnumerator RainCheck()
    {
        yield return new WaitForSeconds(1);

        if (con.active == false)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);

            if (myNumber == 1)
            {
                con.spawner1 = dist;
            }
            if (myNumber == 2)
            {
                con.spawner2 = dist;
            }
            if (myNumber == 3)
            {
                con.spawner3 = dist;
            }
            if (myNumber == 4)
            {
                con.spawner4 = dist;
            }
            if (myNumber == 5)
            {
                con.spawner5 = dist;
            }
            if (myNumber == 6)
            {
                con.spawner6 = dist;
            }


            if (con.winningNumber == dist)
            {
                con.winner = this.gameObject;
            }
        }

        StartCoroutine(RainCheck());
    }
}
