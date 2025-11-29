using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointTest : MonoBehaviour
{
    public float distance;
    public GameObject marker;

    public GameObject player;
    public bool called;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.parent = player.transform;
        this.gameObject.transform.position = player.transform.position;
        Patrol();
    }

    public void Patrol()
    {
        if (!called)
        {
            called = true;
            Invoke("Patrol2", 2);
        }
    }

    public void Patrol2()
    {
        Vector3 point;
        if (RandomPoint(transform.position, distance, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            marker.transform.position = point;
            distance -= 0.5f;
            if (distance < 0)
            {
                distance = 0;
            }
        }
        called = false;
    }

    bool RandomPoint(Vector3 center, float distance, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * (distance);
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
