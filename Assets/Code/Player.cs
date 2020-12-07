using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float BestLapTime { get; private set; } = 9999999;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public float CurrentLap = 0;

    private float lapStartTime;
    public int lastCheckPointPassed = 0;

    private Transform checkpointsParent;

    public int checkpointCount;
    //private checkpointLayer;

    void Start()
    {
        checkpointsParent = GameObject.Find("Checkpoints").transform;
        checkpointCount = checkpointsParent.childCount;
        //checkpointLayer = LayerMask.NameToLayer("Checkpoint");

        //CharacterController = GetComponent(<CarController>)
    }

    // Update is called once per frame
    void Update()
    {
        CurrentLapTime = lapStartTime > 0 ? Time.time - lapStartTime : 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        print(collider);
        if (collider.gameObject.name == "0")
        {
            if (lastCheckPointPassed == checkpointCount - 1)
            {
                lapFinished();
                newLap();
            } else if (CurrentLap == 0)
            {
                newLap();
            }
        } else if (collider.gameObject.name == (lastCheckPointPassed + 1).ToString())
        {
            lastCheckPointPassed++;
        }

        print(lastCheckPointPassed);
    }

    void newLap()
    {
        print("new lap");
        CurrentLap++;
        lastCheckPointPassed = 0;
        lapStartTime = Time.time;
    }

    void lapFinished()
    {
        print("finished lap");
        LastLapTime = Time.time - lapStartTime;
        BestLapTime = Mathf.Min(BestLapTime, LastLapTime);
    }
}