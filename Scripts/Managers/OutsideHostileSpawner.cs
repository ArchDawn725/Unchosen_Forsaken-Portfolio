using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OutsideHostileSpawner : MonoBehaviour
{
    public bool generationOver;
    public NavMeshSurface[] navMeshSurfaces;

    public float spawnSpeed;

    public GameObject[] spawners;
    public GameObject[] insideSpawners;
    public GameObject[] advancedSpawners;

    public GameObject shooken;
    public int shookenSpawned;
    public int shookenSet;

    public GameObject[] shadow;
    public int shadowSpawned;
    public int shadowSet;

    public GameObject stalker;
    public int stalkerSpawned;
    public int stalkerSet;

    public GameObject mother;
    public int motherSpawned;
    public int motherSet;

    public GameObject baby;
    public int babySpawned;
    public int babySet;

    public GameObject spider;
    public int spiderSpawned;
    public int spiderSet;

    public GameObject head;
    public int headSpawned;
    public int headSet;

    public GameObject watcher;
    public int watcherSpawned;
    public int watcherSet;

    public GameObject eve;
    public int eveSpawned;
    public int eveSet;

    public GameObject handicap;
    public int handicapSpawned;
    public int handicapSet;

    public GameObject brute;
    public int bruteSpawned;
    public int bruteSet;

    public GameObject lurker;
    public int lurkerSpawned;
    public int lurkerSet;

    public GameObject leech;
    public int leechSpawned;
    public int leechSet;

    public GameObject skeleton;
    public int skeletonSpawned;
    public int skeletonSet;

    public GameObject undying;
    public int undyingSpawned;
    public int undyingSet;

    public GameObject anger;
    public int angerSpawned;
    public int angerSet;

    public GameObject admirer;
    public int admirerSpawned;
    public int admirerSet;

    public GameObject cat;
    public int catSpawned;
    public int catSet;

    public GameObject mutant;
    public int mutantSpawned;
    public int mutantSet;

    public GameObject skook;
    public int skookSpawned;
    public int skookSet;

    public GameObject[] spawner;
    public GameObject husk;
    public int huskSpawned;
    public int huskSet;

    public GameObject reaper;
    public int reaperSpawned;
    public int repaerSet;

    public void Start()
    {
        //fix this
        //RunNav();
        if (generationOver)
        {
            StartCoroutine(Spawning());
        }
        generationOver = true;
    }

    public void RunNav()
    {
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }

    public IEnumerator Spawning()
    {
        yield return new WaitForSeconds(spawnSpeed);
        insideSpawners = GameObject.FindGameObjectsWithTag("InsideSpawner");
        spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        advancedSpawners = GameObject.FindGameObjectsWithTag("AdvancedSpawner");

        while (shookenSpawned < shookenSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, spawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(shooken/*[Zone1Index]*/, spawners[Zone1SpawnersIndex].transform.position, spawners[Zone1SpawnersIndex].transform.rotation);
            shookenSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("shooken done");

        yield return new WaitForSeconds(spawnSpeed);

        while (shadowSpawned < shadowSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            int Zone1Index = Random.Range(0, shadow.Length);
            Instantiate(shadow[Zone1Index], insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            shadowSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("shadow done");

        yield return new WaitForSeconds(spawnSpeed);

        while (stalkerSpawned < stalkerSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, spawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(stalker/*[Zone1Index]*/, spawners[Zone1SpawnersIndex].transform.position, spawners[Zone1SpawnersIndex].transform.rotation);
            stalkerSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }

        print("stalker done");

        yield return new WaitForSeconds(spawnSpeed);

        while (motherSpawned < motherSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(mother/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            motherSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }

        print("mother done");

        yield return new WaitForSeconds(spawnSpeed);

        while (babySpawned < babySet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(baby/*[Zone1Index]*/, insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            babySpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("baby done");

        yield return new WaitForSeconds(spawnSpeed);

        while (spiderSpawned < spiderSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(spider/*[Zone1Index]*/, insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            spiderSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Spider done");

        yield return new WaitForSeconds(spawnSpeed);

        while (headSpawned < headSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(head/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            headSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Head done");

        yield return new WaitForSeconds(spawnSpeed);

        while (watcherSpawned < watcherSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(watcher/*[Zone1Index]*/, insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            watcherSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Watcher done");

        yield return new WaitForSeconds(spawnSpeed);

        while (eveSpawned < eveSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(eve/*[Zone1Index]*/, insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            eveSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Eve done");
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        yield return new WaitForSeconds(spawnSpeed);

        while (handicapSpawned < handicapSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(handicap/*[Zone1Index]*/, insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            handicapSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Handi done");

        yield return new WaitForSeconds(spawnSpeed);

        while (bruteSpawned < bruteSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(brute/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            bruteSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Brute done");

        yield return new WaitForSeconds(spawnSpeed);

        while (lurkerSpawned < lurkerSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(lurker/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            lurkerSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Lurker done");

        yield return new WaitForSeconds(spawnSpeed);

        while (leechSpawned < leechSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, insideSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(leech/*[Zone1Index]*/, insideSpawners[Zone1SpawnersIndex].transform.position, insideSpawners[Zone1SpawnersIndex].transform.rotation);
            leechSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Leech done");

        yield return new WaitForSeconds(spawnSpeed);

        while (skeletonSpawned < skeletonSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, spawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(skeleton/*[Zone1Index]*/, spawners[Zone1SpawnersIndex].transform.position, spawners[Zone1SpawnersIndex].transform.rotation);
            skeletonSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Skeleton done");

        yield return new WaitForSeconds(spawnSpeed);

        while (undyingSpawned < undyingSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, spawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(undying/*[Zone1Index]*/, spawners[Zone1SpawnersIndex].transform.position, spawners[Zone1SpawnersIndex].transform.rotation);
            undyingSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Undying done");

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        while (angerSpawned < angerSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(anger/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            angerSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("anger done");

        while (admirerSpawned < admirerSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(admirer/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            admirerSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Admirer done");

        while (catSpawned < catSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(cat/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            catSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Cat done");

        while (mutantSpawned < mutantSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(mutant/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            mutantSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Mutant done");

        while (skookSpawned < skookSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, spawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(skook/*[Zone1Index]*/, spawners[Zone1SpawnersIndex].transform.position, spawners[Zone1SpawnersIndex].transform.rotation);
            skookSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Skook done");

        yield return new WaitForSeconds(spawnSpeed);

        while (huskSpawned < huskSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            spawner = GameObject.FindGameObjectsWithTag("HuskSpawner");
            int Zone1SpawnersIndex = Random.Range(0, spawner.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(husk/*[Zone1Index]*/, spawner[Zone1SpawnersIndex].transform.position, spawner[Zone1SpawnersIndex].transform.rotation);
            huskSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Husk done");

        while (reaperSpawned < repaerSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            int Zone1SpawnersIndex = Random.Range(0, advancedSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(reaper/*[Zone1Index]*/, advancedSpawners[Zone1SpawnersIndex].transform.position, advancedSpawners[Zone1SpawnersIndex].transform.rotation);
            reaperSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("reaper done");
    }
}
