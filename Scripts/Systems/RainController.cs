using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public bool active;

    public GameObject[] rainSpawns;
    public GameObject rain;

    public float spawner1;
    public float spawner2;
    public float spawner3;
    public float spawner4;
    public float spawner5;
    public float spawner6;

    public float winningNumber;
    public GameObject winner;

    public GameObject rainSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RainCheck());
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Vector3 pos = this.gameObject.transform.position;
            pos.y = 4.8f;
            rain.transform.position = pos;

            //rain.transform.position = Vector3(this.gameObject.transform.position.x , y=4.8f ,this.gameObject.transform.position.z);//4.8
            rainSound.SetActive(false);
        }
        else
        {
            rain.transform.position = winner.transform.position;
            rainSound.SetActive(true);
        }
    }

    IEnumerator RainCheck()
    {
        yield return new WaitForSeconds(1);

        if (!active)
        {
            winningNumber = Mathf.Min(spawner1, spawner2, spawner3, spawner4, spawner5);

            //rain.transform.position = winner.transform.position;
        }

        StartCoroutine(RainCheck());
    }
}
