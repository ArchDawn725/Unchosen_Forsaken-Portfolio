using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapControllerS : MonoBehaviour
{
    public bool hasStarted;

    public GameObject elevator;
    public GameObject safeRoom;

    public GameObject[] defualtHallways;
    public GameObject[] hallways;

    public GameObject[] defualtInsideRooms;
    public GameObject[] insideRooms;

    public GameObject[] defualtOutsideRooms;
    public GameObject[] outsideRooms;

    public float spawnSpeed;

    public NavMeshSurface[] navMeshSurfaces;

    // Start is called before the first frame update
    void Start()
    {
        defualtHallways = GameObject.FindGameObjectsWithTag("BlankHall");
        defualtOutsideRooms = GameObject.FindGameObjectsWithTag("BlankOutsideRoom");
        defualtInsideRooms = GameObject.FindGameObjectsWithTag("BlankInsideRoom");

        if (!hasStarted)
        {
            StartCoroutine(SafeRoomSpawning());
            hasStarted = true;
        }
    }

    public IEnumerator SafeRoomSpawning()
    {
        yield return new WaitForSeconds(spawnSpeed);

        int Zone1SpawnersIndex = Random.Range(0, defualtOutsideRooms.Length);
        if (defualtOutsideRooms[Zone1SpawnersIndex] != null)
        {
            Instantiate(safeRoom, defualtOutsideRooms[Zone1SpawnersIndex].transform.position, defualtOutsideRooms[Zone1SpawnersIndex].transform.rotation);
        }

        defualtOutsideRooms = GameObject.FindGameObjectsWithTag("BlankOutsideRoom");
        yield return new WaitForSeconds(spawnSpeed);

        StartCoroutine(ElevatorSpawner());
        print("SafeRoom done");
    }

    public IEnumerator ElevatorSpawner()
    {
        yield return new WaitForSeconds(spawnSpeed);

        int Zone1SpawnersIndex = Random.Range(0, defualtInsideRooms.Length);
        if (defualtInsideRooms[Zone1SpawnersIndex] != null)
        {
            Instantiate(elevator, defualtInsideRooms[Zone1SpawnersIndex].transform.position, defualtInsideRooms[Zone1SpawnersIndex].transform.rotation);
        }

        defualtInsideRooms = GameObject.FindGameObjectsWithTag("BlankInsideRoom");
        yield return new WaitForSeconds(spawnSpeed);

        print("elevator done");
        StartCoroutine(PreWorldGen());
    }

    public IEnumerator PreWorldGen()
    {
        yield return new WaitForSeconds(spawnSpeed);

        while (defualtHallways.Length > 0)
        {
            int Zone1SpawnersIndex = Random.Range(0, defualtHallways.Length);
            int Zone1Index = Random.Range(0, hallways.Length);
            if (defualtHallways[Zone1SpawnersIndex] != null)
            {
                Instantiate(hallways[Zone1Index], defualtHallways[Zone1SpawnersIndex].transform.position, defualtHallways[Zone1SpawnersIndex].transform.rotation);
            }

            defualtHallways = GameObject.FindGameObjectsWithTag("BlankHall");
            yield return new WaitForSeconds(spawnSpeed);
        }

        if (defualtHallways.Length == 0)
        {
            StartCoroutine(WorldGen());
            print("hallways done");
        }
    }

    public IEnumerator WorldGen()
    {
        yield return new WaitForSeconds(spawnSpeed);

        while (defualtOutsideRooms.Length > 0)
        {
            int Zone1SpawnersIndex = Random.Range(0, defualtOutsideRooms.Length);
            int Zone1Index = Random.Range(0, outsideRooms.Length);
            if (defualtOutsideRooms[Zone1SpawnersIndex] != null)
            {
                Instantiate(outsideRooms[Zone1Index], defualtOutsideRooms[Zone1SpawnersIndex].transform.position, defualtOutsideRooms[Zone1SpawnersIndex].transform.rotation);
            }

            defualtOutsideRooms = GameObject.FindGameObjectsWithTag("BlankOutsideRoom");
            yield return new WaitForSeconds(spawnSpeed);
        }

        if (defualtOutsideRooms.Length == 0)
        {
            StartCoroutine(PostWorldGen());
            print("outside rooms done");
        }
    }

    public IEnumerator PostWorldGen()
    {
        yield return new WaitForSeconds(spawnSpeed);

        while (defualtInsideRooms.Length > 0)
        {
            int Zone1SpawnersIndex = Random.Range(0, defualtInsideRooms.Length);
            int Zone1Index = Random.Range(0, insideRooms.Length);
            if (defualtInsideRooms[Zone1SpawnersIndex] != null)
            {
                Instantiate(insideRooms[Zone1Index], defualtInsideRooms[Zone1SpawnersIndex].transform.position, defualtInsideRooms[Zone1SpawnersIndex].transform.rotation);
            }

            defualtInsideRooms = GameObject.FindGameObjectsWithTag("BlankInsideRoom");
            yield return new WaitForSeconds(spawnSpeed);
        }

        if (defualtInsideRooms.Length == 0)
        {
            for (int i = 0; i < navMeshSurfaces.Length; i++)
            {
                navMeshSurfaces[i].BuildNavMesh();
            }
            print("inside rooms done");
        }
    }
}
