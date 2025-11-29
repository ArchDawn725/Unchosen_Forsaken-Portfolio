using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour
{
    public GameObject player;
    public Player playerS;

    public Animation referenceToAnimation;
    public GameObject itemUse;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerS = player.GetComponent("Player") as Player;
    }

    public void LeverPulled()
    {
        playerS.leverPulled = true;
        referenceToAnimation.Play();
        Instantiate(itemUse, gameObject.transform.position, gameObject.transform.rotation);
    }
}
