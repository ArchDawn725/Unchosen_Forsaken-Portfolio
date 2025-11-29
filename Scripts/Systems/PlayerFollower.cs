using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject playerCamera;
    public SightRadar cam;

    public Vector3 loc;
    // Start is called before the first frame update
    void Start()
    {
        /*
        if (this.gameObject == "PlayerMarker(1)")
        {
            Destroy(this.gameObject);
        }
        */
        playerCamera = GameObject.Find("Camera (head)");
        cam = playerCamera.GetComponent("SightRadar") as SightRadar;
        StartCoroutine(Controller());
    }

    IEnumerator Controller()
    {
        yield return new WaitForSeconds(1);
        loc = cam.loc;
        this.gameObject.transform.position = loc;
        print(loc);
        StartCoroutine(Controller());
    }
}
