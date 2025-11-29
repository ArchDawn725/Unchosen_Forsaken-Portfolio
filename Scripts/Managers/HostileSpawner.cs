using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HostileSpawner : MonoBehaviour
{
    public bool generationOver;
    public bool runNav;
    [Space(20)]

    public float waitTimer = 120;
    public float luckyNumber;
    public int spawnerNumber;
    public int numberOfHostiles;
    public int numberSpawned;
    public int maxSpawned;
    public bool tryingSpawn;
    [Space(20)]

    public NavMeshSurface[] navMeshSurfaces;
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
    [Space(10)]
    public GameObject undying;
    public int undyingSpawned;
    public int undyingSet;
    [Space(10)]
    public GameObject leech;
    public int leechSpawned;
    public int leechSet;
    [Space(10)]
    public GameObject handicap;
    public int handicapSpawned;
    public int handicapSet;
    [Space(10)]
    public GameObject skeleton;
    public int skeletonSpawned;
    public int skeletonSet;
    [Space(10)]
    public GameObject lurker;
    public int lurkerSpawned;
    public int lurkerSet;
    [Space(10)]
    public GameObject brute;
    public int bruteSpawned;
    public int bruteSet;
    [Space(10)]
    public GameObject skook;
    public int skookSpawned;
    public int skookSet;
    [Space(10)]
    public GameObject anger;
    public int angerSpawned;
    public int angerSet;
    [Space(10)]
    public GameObject cat;
    public int catSpawned;
    public int catSet;
    [Space(10)]
    public GameObject mutant;
    public int mutantSpawned;
    public int mutantSet;
    [Space(10)]
    public GameObject admirer;
    public int admirerSpawned;
    public int admirerSet;
    [Space(10)]
    public GameObject reaper;
    public int reaperSpawned;
    public int repaerSet;


    //____________________________________________________________________________________________________________________________________________________________________________________________



    // Start is called before the first frame update
    void Start()
    {
        maxSpawned = huskSet + ghostSet + shookenSet + shadowSet + spiderSet + headSet + babySet + stalkerSet + watcherSet + eveSet + undyingSet + leechSet + handicapSet + skeletonSet + lurkerSet + bruteSet + skookSet + angerSet + catSet + mutantSet + admirerSet + repaerSet;

        if (generationOver)
        {
            if (runNav)
            {
                for (int i = 0; i < navMeshSurfaces.Length; i++)
                {
                    navMeshSurfaces[i].BuildNavMesh();
                }
            }
            numberOfHostiles = 22;
            StartCoroutine(Timer());

            hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
            spawnerNumber = Random.Range(0, hallSpawners.Length);
            Instantiate(mother, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
            print("Mother Spawned");
        }
        else
        {
            generationOver = true;
        }
    }

    IEnumerator Timer()
    {
        while (numberSpawned < maxSpawned)
        {
            yield return new WaitForSeconds(waitTimer);
            Randomnumber();
            //StartCoroutine(Timer());
            print("timer call");
        }
        print("done Spawning");

    }

    public void Randomnumber()
    {
        if (numberSpawned < maxSpawned && !tryingSpawn)
        {
            luckyNumber = Random.Range(1, numberOfHostiles);
            tryingSpawn = true;
            Invoke("SpawnPicker", 0.5f);
        }
    }

    public void Delay()
    {
        Invoke("Randomnumber", 0.5f);
    }

    public void SpawnPicker()
    {
        if (luckyNumber == 1)
        {
            if (huskSpawned < huskSet)
            {
                SpawnHusk();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 2)
        {
            if (ghostSpawned < ghostSet)
            {
                SpawnGhost();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 3)
        {
            if (shookenSpawned < shookenSet)
            {
                SpawnShooken();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 4)
        {
            if (shadowSpawned < shadowSet)
            {
                SpawnShadow();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 5)
        {
            if (spiderSpawned < spiderSet)
            {
                SpawnSpider();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 6)
        {
            if (headSpawned < headSet)
            {
                SpawnHead();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 7)
        {
            if (babySpawned < babySet)
            {
                SpawnBaby();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 8)
        {
            if (stalkerSpawned < stalkerSet)
            {
                SpawnStalker();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 9)
        {
            if (watcherSpawned < watcherSet)
            {
                SpawnWatcher();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 10)
        {
            if (eveSpawned < eveSet)
            {
                SpawnEve();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        //____________________________________________________________________________________________________________________________________________________________________

        if (luckyNumber == 11)
        {
            if (undyingSpawned < undyingSet)
            {
                SpawnUndying();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 12)
        {
            if (leechSpawned < leechSet)
            {
                SpawnLeech();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 13)
        {
            if (handicapSpawned < handicapSet)
            {
                SpawnHandicap();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 14)
        {
            if (skeletonSpawned < skeletonSet)
            {
                SpawnSkeleton();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 15)
        {
            if (lurkerSpawned < lurkerSet)
            {
                SpawnLurker();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 16)
        {
            if (bruteSpawned < bruteSet)
            {
                SpawnBrute();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        //_________________________________________________________________________________________________________________________________________________________________________________

        if (luckyNumber == 17)
        {
            if (skookSpawned < skookSet)
            {
                SpawnSkook();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 18)
        {
            if (angerSpawned < angerSet)
            {
                SpawnAnger();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 19)
        {
            if (catSpawned < catSet)
            {
                SpawnCat();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 20)
        {
            if (mutantSpawned < mutantSet)
            {
                SpawnMutant();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 21)
        {
            if (admirerSpawned < admirerSet)
            {
                SpawnAdmirer();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }

        if (luckyNumber == 22)
        {
            if (reaperSpawned < repaerSet)
            {
                SpawnReaper();
            }
            else
            {
                tryingSpawn = false;
                Delay();
            }
        }
    }


    //____________________________________________________________________________________________________________________________________________________________________________________________



    public void SpawnHusk()
    {
        huskSpawners = GameObject.FindGameObjectsWithTag("HuskSpawner");
        spawnerNumber = Random.Range(0, huskSpawners.Length);
        Instantiate(husk, huskSpawners[spawnerNumber].transform.position, huskSpawners[spawnerNumber].transform.rotation);
        huskSpawned++;
        print("Husk Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnGhost()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(ghost, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        ghostSpawned++;
        print("Ghost Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnShooken()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(shooken, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        shookenSpawned++;
        print("Shooken Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnShadow()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(shadow, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        shadowSpawned++;
        print("Shadow Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnSpider()
    {
        hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
        spawnerNumber = Random.Range(0, hallSpawners.Length);
        Instantiate(spider, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
        spiderSpawned++;
        print("Spider Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnHead()
    {
        hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
        spawnerNumber = Random.Range(0, hallSpawners.Length);
        Instantiate(head, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
        headSpawned++;
        print("Head Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnBaby()
    {
        hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
        spawnerNumber = Random.Range(0, hallSpawners.Length);
        Instantiate(baby, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
        babySpawned++;
        print("Baby Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnStalker()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(stalker, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        stalkerSpawned++;
        print("Stalker Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnWatcher()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(watcher, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        watcherSpawned++;
        print("Watcher Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnEve()
    {
        hallSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
        spawnerNumber = Random.Range(0, hallSpawners.Length);
        Instantiate(eve, hallSpawners[spawnerNumber].transform.position, hallSpawners[spawnerNumber].transform.rotation);
        eveSpawned++;
        print("Eve Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnUndying()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(undying, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        undyingSpawned++;
        print("Undying Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnLeech()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(leech, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        leechSpawned++;
        print("Leech Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnHandicap()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(handicap, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        handicapSpawned++;
        print("Handicap Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnSkeleton()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(skeleton, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        skeletonSpawned++;
        print("Skeleton Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnLurker()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(lurker, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        lurkerSpawned++;
        print("Lurker Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnBrute()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(brute, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        bruteSpawned++;
        print("Brute Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnSkook()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(skook, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        skookSpawned++;
        print("Skook Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnAnger()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(anger, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        angerSpawned++;
        print("Anger Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnCat()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(cat, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        catSpawned++;
        print("Cat Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnMutant()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(mutant, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        mutantSpawned++;
        print("Mutant Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnAdmirer()
    {
        anywhereSpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        spawnerNumber = Random.Range(0, anywhereSpawners.Length);
        Instantiate(admirer, anywhereSpawners[spawnerNumber].transform.position, anywhereSpawners[spawnerNumber].transform.rotation);
        admirerSpawned++;
        print("Admirer Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }

    public void SpawnReaper()
    {
        giantSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");
        spawnerNumber = Random.Range(0, giantSpawners.Length);
        Instantiate(reaper, giantSpawners[spawnerNumber].transform.position, giantSpawners[spawnerNumber].transform.rotation);
        reaperSpawned++;
        print("Reaper Spawned");
        numberSpawned++;
        tryingSpawn = false;
    }
}

