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
    public bool WrongDirection { get; private set; } = false;
    public float currentLap = 0;

    private float _lapStartTime;
    public int lastCheckPointPassed = 0;

    public int checkpointCount;
    [SerializeField] private List<GameObject> checkpoints;
    private Rigidbody _carBody;

    [SerializeField] private Button resetButton;


    void Start()
    {
        checkpointCount = checkpoints.Count;
        resetButton.onClick.AddListener(ResetCarPositionToLastCheckpoint);
        _carBody = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(CheckIfWrongDirection), 0,
            1); // only check every second if the player is driving in the wrong direction to save performance
        BestLapTime = save.GetBestTime();
    }

    void Update()
    {
        CurrentLapTime = _lapStartTime > 0 ? Time.time - _lapStartTime : 0;
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        var checkPointPassed = colliderObject.gameObject;
        // if passed first/last checkpoint
        if (GameObject.ReferenceEquals(checkPointPassed, checkpoints[0]))
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
        } // else if passed lastCheckpoint+1 (the right next one)
        else if (GameObject.ReferenceEquals(checkPointPassed, checkpoints[lastCheckPointPassed + 1]))
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
        save.SaveBestTime((BestLapTime));
    }

    private void CheckIfWrongDirection()
    {
        var nextCheckpoint = GetNextCheckpoint();
        var targetDir = nextCheckpoint.transform.position - transform.position;
        var angle = Vector3.Angle(targetDir, transform.forward);
        WrongDirection = angle > 110.0f;
    }

    private void ResetCarPositionToLastCheckpoint()
    {
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

    private GameObject GetNextCheckpoint()
    {
        var index = lastCheckPointPassed == checkpoints.Count - 1 ? 0 : lastCheckPointPassed + 1;
        return checkpoints[index];
    }
}