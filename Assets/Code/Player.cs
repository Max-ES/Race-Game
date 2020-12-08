using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BestLapTime { get; private set; } = 9999999;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public float currentLap = 0;

    private float _lapStartTime;
    public int lastCheckPointPassed = 0;

    public int checkpointCount;

    void Start()
    {
        checkpointCount = GameObject.Find("Checkpoints").transform.childCount;
    }

    void Update()
    {
        CurrentLapTime = _lapStartTime > 0 ? Time.time - _lapStartTime : 0;
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        print(colliderObject);
        if (colliderObject.gameObject.name == "0")
        {
            if (lastCheckPointPassed == checkpointCount - 1)
            {
                LapFinished();
                NewLap();
            } else if (currentLap == 0)
            {
                NewLap();
            }
        } else if (colliderObject.gameObject.name == (lastCheckPointPassed + 1).ToString())
        {
            lastCheckPointPassed++;
        }
    }

    private void NewLap()
    {
        currentLap++;
        lastCheckPointPassed = 0;
        _lapStartTime = Time.time;
    }

    private void LapFinished()
    {
        LastLapTime = Time.time - _lapStartTime;
        BestLapTime = Mathf.Min(BestLapTime, LastLapTime);
    }
}