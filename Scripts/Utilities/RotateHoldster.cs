using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHoldster : MonoBehaviour
{
    public GameObject anchor;
    public float rotationSpeed = 50;
    public float height = 1.5f;

    public void Update()
    {
        transform.localPosition = new Vector3(anchor.transform.localPosition.x, anchor.transform.localPosition.y / height, anchor.transform.localPosition.z);

        var rotationDifference = Math.Abs(anchor.transform.eulerAngles.y - transform.eulerAngles.y);
        var finalRotationSpeed = rotationSpeed;

        if(rotationDifference>60)
        {
            finalRotationSpeed = rotationSpeed * 2;
        }
        else if (rotationDifference > 40 && rotationDifference < 60)
        {
            finalRotationSpeed = rotationSpeed;
        }
        else if (rotationDifference < 40 && rotationDifference > 20)
        {
            finalRotationSpeed = rotationSpeed / 2;
        }
        else if (rotationDifference < 20 && rotationDifference > 0)
        {
            finalRotationSpeed = rotationSpeed / 4;
        }

        var step = finalRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, anchor.transform.eulerAngles.y, 0), step);
    }
}
