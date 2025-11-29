using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public bool startAnyway;

    public GameObject[] itemSpawners;
    public float spawnSpeed;


    public GameObject key;
    public GameObject oldFlashLight;
    public GameObject utilityLight;
    public GameObject magLight;
    public GameObject theTorch;
    public GameObject oil;
    public GameObject battery;
    public GameObject energy;
    public GameObject antidote;
    public GameObject flare;
    public GameObject lighter;
    public GameObject matches;
    public GameObject speedPotion;

    public int keysSpawned;
    public int keysSet;
    public int oldFlashLightSpawned;
    public int oldFlashLightSet;
    public int utilityLightSpawned;
    public int utilityLightSet;
    public int magLightSpawned;
    public int magLightSet;
    public int theTorchSpawned;
    public int theTorchSet;
    public int oilSpawned;
    public int oilsSet;
    public int batterySpawned;
    public int batterySet;
    public int energySpawned;
    public int energySet;
    public int antidoteSpawned;
    public int antidoteSet;
    public int flareSpawned;
    public int flareSet;
    public int lighterSpawned;
    public int lighterSet;
    public int MatchesSpawned;
    public int MatchesSet;
    public int speedPotionSpawned;
    public int speedPotionSet;

    public void Start()
    {
        if (startAnyway)
        {
            OnStart();
        }
        else
        {
            startAnyway = true;
        }
    }

    public void OnStart()
    {
        itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
        StartCoroutine(ItemSpawning());
    }

    public IEnumerator ItemSpawning()
    {
        yield return new WaitForSeconds(spawnSpeed);

        while (keysSpawned < keysSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(key/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            keysSpawned++;


            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Key Spawned");

        while (oldFlashLightSpawned < oldFlashLightSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(oldFlashLight/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            oldFlashLightSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("oldFlashLight Spawned");

        while (utilityLightSpawned < utilityLightSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(utilityLight/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            utilityLightSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("utilityLight Spawned");

        while (magLightSpawned < magLightSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(magLight/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            magLightSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("magLight Spawned");

        while (theTorchSpawned < theTorchSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(theTorch/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            theTorchSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("theTorch Spawned");

        while (oilSpawned < oilsSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(oil/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            oilSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("oil Spawned");

        while (batterySpawned < batterySet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(battery/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            batterySpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("battery Spawned");

        while (energySpawned < energySet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(energy/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            energySpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("energy Spawned");

        while (antidoteSpawned < antidoteSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(antidote/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            antidoteSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("antidote Spawned");

        while (flareSpawned < flareSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(flare/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            flareSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("flare Spawned");

        while (lighterSpawned < lighterSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(lighter/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            lighterSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("lighter Spawned");

        while (MatchesSpawned < MatchesSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(matches/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            MatchesSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("Matches Spawned");

        while (speedPotionSpawned < speedPotionSet)
        {
            yield return new WaitForSeconds(spawnSpeed);

            itemSpawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
            int Zone1SpawnersIndex = Random.Range(0, itemSpawners.Length);
            //int Zone1Index = Random.Range(0, zone1.Length);
            Instantiate(speedPotion/*[Zone1Index]*/, itemSpawners[Zone1SpawnersIndex].transform.position, itemSpawners[Zone1SpawnersIndex].transform.rotation);
            speedPotionSpawned++;

            yield return new WaitForSeconds(spawnSpeed);
        }
        print("SpeedPotion Spawned");
    }
}
