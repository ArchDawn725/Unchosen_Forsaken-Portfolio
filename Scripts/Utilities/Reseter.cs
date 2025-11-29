using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delay", 0.5f);
    }
    public void Delay()
    {
        SceneManager.LoadScene(0);
    }
}
