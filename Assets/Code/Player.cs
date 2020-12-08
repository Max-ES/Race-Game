using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float BestLapTime { get; private set; } = 9999999;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public float currentLap = 0;

    private float _lapStartTime;
    public int lastCheckPointPassed = 0;

    public int checkpointCount;
    [SerializeField] private List<GameObject> checkpoints;
    private Rigidbody _carBody;

    public Button resetButton;
    
    

    void Start()
    {
        checkpointCount = checkpoints.Count;
        resetButton.onClick.AddListener(ResetCarPositionToLastCheckpoint);
        _carBody = GetComponent<Rigidbody>();
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
            }
            else if (currentLap == 0)
            {
                NewLap();
            }
        }
        else if (colliderObject.gameObject.name == (lastCheckPointPassed + 1).ToString())
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

    private void ResetCarPositionToLastCheckpoint()
    {
        print("reset");
        Vector3 a = transform.localRotation.eulerAngles;
        a.x = 0;
        a.y = Mathf.Repeat(a.y + Input.GetAxis("Horizontal") * 5f, 360f);
        a.z = 0;
        transform.localRotation = Quaternion.Euler(a);

        var lastCheckpoint = GetLastPassedCheckpoint();
        
        transform.position = lastCheckpoint.transform.position;
        transform.rotation = lastCheckpoint.transform.rotation;
        _carBody.velocity = Vector3.zero;
    }

    private GameObject GetLastPassedCheckpoint()
    {
        return checkpoints[lastCheckPointPassed];
    }
}