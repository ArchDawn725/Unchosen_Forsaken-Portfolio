using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introScript : MonoBehaviour
{
    public Player players;
    public GameObject player;
    public Camera camera;

    public int oldMask;

    public Light light;
    public GameObject startLocation;
    public GameObject introLocation;

    public GameObject moonLight;

    public GameObject intro1;

    // Start is called before the first frame update
    void Start()
    {
        startLocation = GameObject.Find("Start Pos");
        intro1.SetActive(true);
        player.gameObject.transform.position = introLocation.transform.position;
        moonLight.SetActive(false);
        light.range = 4;
        oldMask = camera.cullingMask;
        //camera.cullingMask = 0;
        camera.nearClipPlane = 0.05f;
        camera.farClipPlane = 5f;
        players.speed = 0;
        players.currentSpeed = 0;
        Invoke("StartGame", 10);
        Destroy(intro1, 15);

    }

    public void StartGame()
    {
        players.hour = 6; players.minute = 0;
        player.gameObject.transform.position = startLocation.transform.position;
        moonLight.SetActive(true);
        light.range = 4;
        camera.nearClipPlane = 0.05f;
        camera.farClipPlane = 5f;
        camera.cullingMask = oldMask;
        players.speed = 1.5f;
        players.currentSpeed = 1.5f;
        StartCoroutine(View());
        StartCoroutine(View2());
    }

    IEnumerator View()
    {
        while (camera.farClipPlane < 20)
        {
            yield return new WaitForSeconds(0.01f);
            camera.farClipPlane+=0.2f;
        }
    }
    IEnumerator View2()
    {
        while (light.range > 0)
        {
            yield return new WaitForSeconds(0.01f);
            light.range -= 0.1f;
        }
    }

    public void Activate()
    {
        camera.nearClipPlane = 0.05f;
        camera.farClipPlane = 5f;
        Invoke("StartGame", 1);
    }
}
