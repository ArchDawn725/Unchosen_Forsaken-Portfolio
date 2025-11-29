using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject player;

    public Animation referenceToAnimation;
    public AnimationClip[] clips;
    public int _currClip = 0;
    // Start is called before the first frame update
    void Start()
    {
        _currClip = 0;
        referenceToAnimation.clip = clips[_currClip];
        referenceToAnimation.Play();
        Invoke("GiveChase", 10);
    }

    // Update is called once per frame
    void Update()
    {
        referenceToAnimation.Play();
    }

    public void GiveChase()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
