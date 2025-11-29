using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner2 : MonoBehaviour
{
    public bool generationOver;
    [Space(20)]

    public float waitTimer = 30;
    public float luckyNumber;
    public int spawnerNumber;
    public int numberOfHostiles = 10;
    public int finishedSpawns;
    [Space(20)]

    public GameObject[] huskSpawners;
    public GameObject[] anywhereSpawners;
    public GameObject[] hallSpawners;
    public GameObject[] giantSpawners;
    [Space(20)]

    public GameObject mother;
    [Space(10)]
    public GameObject husk;
    public int huskSpawned;
    public int huskSet;
    [Space(10)]
    public GameObject ghost;
    public int ghostSpawned;
    public int ghostSet;
    [Space(10)]
    public GameObject shooken;
    public int shookenSpawned;
    public int shookenSet;
    [Space(10)]
    public GameObject shadow;
    public int shadowSpawned;
    public int shadowSet;
    [Space(10)]
    public GameObject spider;
    public int spiderSpawned;
    public int spiderSet;
    [Space(10)]
    public GameObject head;
    public int headSpawned;
    public int headSet;
    [Space(10)]
    public GameObject baby;
    public int babySpawned;
    public int babySet;
    [Space(10)]
    public GameObject stalker;
    public int stalkerSpawned;
    public int stalkerSet;
    [Space(10)]
    public GameObject watcher;
    public int watcherSpawned;
    public int watcherSet;
    [Space(10)]
    public GameObject eve;
    public int eveSpawned;
    public int eveSet;

    // Start is called before the first frame update
    void Start()
    {
        if (generationOver)
        {
            StartCoroutine(Timer());

            anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
            spawnerNumber = Random.Range(0, anywhereSpawners.Length);
            Instantiate(mother, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
            print("Mother Spawned");
        }
    }

    IEnumerator Timer()
    {
        if (finishedSpawns < numberOfHostiles)
        {
            yield return new WaitForSeconds(waitTimer);
            Randomnumber();
            StartCoroutine(Timer());
        }
        else
        {
            print("done Spawning");
        }

    }

    public void Randomnumber()
    {
        luckyNumber = Random.Range(0, numberOfHostiles);
    }

    public void SpawnPicker()
    {
        if (luckyNumber == 1)
        {
            if (huskSpawned < huskSet)
            {
                huskSpawners = GameObject.FindGameObjectsWithTag("HuskSpawner");
                spawnerNumber = Random.Range(0, huskSpawners.Length);
                Instantiate(husk, huskSpawners[spawnerNumber].transform.position, huskSpawners[spawnerNumber].transform.rotation);
                huskSpawned++;
                print("Husk Spawned");
                if (huskSpawned == huskSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 2)
        {
            if (ghostSpawned < ghostSet)
            {
                anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
                spawnerNumber = Random.Range(0, anywhereSpawners.Length);
                Instantiate(ghost, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
                ghostSpawned++;
                print("Ghost Spawned");
                if (ghostSpawned == ghostSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 3)
        {
            if (shookenSpawned < shookenSet)
            {
                anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
                spawnerNumber = Random.Range(0, anywhereSpawners.Length);
                Instantiate(shooken, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
                shookenSpawned++;
                print("Shooken Spawned");
                if (shookenSpawned == shookenSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 4)
        {
            if (shadowSpawned < shadowSet)
            {
                anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
                spawnerNumber = Random.Range(0, anywhereSpawners.Length);
                Instantiate(shadow, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
                shadowSpawned++;
                print("Shadow Spawned");
                if (shadowSpawned == shadowSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 5)
        {
            if (spiderSpawned < spiderSet)
            {
                hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
                spawnerNumber = Random.Range(0, hallSpawners.Length);
                Instantiate(spider, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
                spiderSpawned++;
                print("Spider Spawned");
                if (spiderSpawned == spiderSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 6)
        {
            if (headSpawned < headSet)
            {
                hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
                spawnerNumber = Random.Range(0, hallSpawners.Length);
                Instantiate(head, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
                headSpawned++;
                print("Head Spawned");
                if (headSpawned == headSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 7)
        {
            if (babySpawned < babySet)
            {
                anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
                spawnerNumber = Random.Range(0, anywhereSpawners.Length);
                Instantiate(baby, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
                babySpawned++;
                print("Baby Spawned");
                if (babySpawned == babySet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 8)
        {
            if (stalkerSpawned < stalkerSet)
            {
                anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
                spawnerNumber = Random.Range(0, anywhereSpawners.Length);
                Instantiate(stalker, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
                stalkerSpawned++;
                print("Stalker Spawned");
                if (stalkerSpawned == stalkerSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 9)
        {
            if (watcherSpawned < watcherSet)
            {
                anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
                spawnerNumber = Random.Range(0, anywhereSpawners.Length);
                Instantiate(watcher, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
                watcherSpawned++;
                print("Watcher Spawned");
                if (watcherSpawned == watcherSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }

        if (luckyNumber == 10)
        {
            if (eveSpawned < eveSet)
            {
                hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
                spawnerNumber = Random.Range(0, hallSpawners.Length);
                Instantiate(eve, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
                eveSpawned++;
                print("Eve Spawned");
                if (eveSpawned == eveSet)
                {
                    finishedSpawns++;
                }
            }
            else
            {
                Randomnumber();
            }
        }
    }

    public void SpawnHusk()
    {

    }
}
/*
        huskSpawners = GameObject.FindGameObjectsWithTag("HuskSpawner");
        hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");

            if (luckyNumber == )
        {
            if (spawned < Set)
            {
                Spawners
                spawnerNumber = Random.Range(0, Spawners.Length);
                Instantiate(, Spawners[spawnerNumber].transform.position, Spawners[spawnerNumber].transform.rotation);
                Spawned++;
                print(" Spawned");
            }
            else
            {
                Randomnumber();
            }
        }
*/
