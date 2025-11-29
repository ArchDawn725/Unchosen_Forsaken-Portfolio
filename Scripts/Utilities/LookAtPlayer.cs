using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LookAtPlayer : MonoBehaviour
{

    public GameObject player;
    public ConstraintSource constraintSource;

    // Update is called once per frame
    public void Start()
    {
        player = Camera.main.gameObject;
        AimConstraint aimConstraint = GetComponent<AimConstraint>();

        constraintSource.sourceTransform = player.transform;
        constraintSource.weight = 1;
        aimConstraint.AddSource(constraintSource); 

    }
    void Update()
    {
        //this.gameObject.transform.LookAt(player.transform);
    }
}
