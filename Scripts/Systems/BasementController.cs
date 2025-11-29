using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementController : MonoBehaviour
{
    public int powerRooms;
    public int rooms;
    public int hallways;
    public int corridors;

    public int powerRoomsMax;
    public int roomsMax;
    public int hallwaysMax;
    public int corridorsMax;

    public bool timed;
    public bool timeOver;

    public int timer = 20;

    public bool generationOver;

    public float spawnSpeed;

    public void Start()
    {
        Invoke("Starting", timer);
        Invoke("Stopping", (timer*2));

        generationOver = true;
    }

    public void Starting()
    {
        timed = true;
    }

    public void Stopping()
    {
        timeOver = true;
    }
}
