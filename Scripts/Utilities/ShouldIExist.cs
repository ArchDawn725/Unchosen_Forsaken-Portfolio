using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldIExist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Backpack");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
}
