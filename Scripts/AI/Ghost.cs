using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(5);
        Vector3 point;
        if (RandomPoint(transform.position, 30, out point))
        {
            navMeshAgent.destination = point;
        }
        StartCoroutine(Patrol());
    }

    bool RandomPoint(Vector3 center, float fleeDist, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * (fleeDist / 2);
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
