using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject UIRacePanel;

    public Text UITextCurrentLap;
    public Text UITextCurrentTime;
    public Text UITextLastLap;
    public Text UITextBestLap;
    public Text UITextCheckpoint;

    public Player UpdateUIForPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UITextCurrentLap.text = $"Runde: {UpdateUIForPlayer.CurrentLap}";
        UITextCurrentTime.text = $"Zeit: {UpdateUIForPlayer.CurrentLapTime}s";
        UITextLastLap.text = $"Letzte Rundenzeit: {UpdateUIForPlayer.LastLapTime}s";
        UITextBestLap.text = $"Bestzeit: {UpdateUIForPlayer.BestLapTime}s";
        UITextCheckpoint.text = $"Checkpoint: {UpdateUIForPlayer.lastCheckPointPassed}/{UpdateUIForPlayer.checkpointCount}";
    }
}
