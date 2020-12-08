using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI uITextCurrentLap;
    public TextMeshProUGUI uITextCurrentTime;
    public TextMeshProUGUI uITextLastLap;
    public TextMeshProUGUI uITextBestLap;
    public TextMeshProUGUI uITextCheckpoint;
    public TextMeshProUGUI uITextWrongDirection;

    public Player updateUIForPlayer;

    private void Update()
    {
        uITextCurrentLap.text = $"Runde: {updateUIForPlayer.currentLap}";
        uITextCurrentTime.text = $"Zeit: {updateUIForPlayer.CurrentLapTime}s";
        uITextLastLap.text = $"Letzte Rundenzeit: {updateUIForPlayer.LastLapTime}s";
        uITextBestLap.text = $"Bestzeit: {updateUIForPlayer.BestLapTime}s";
        uITextCheckpoint.text = $"Checkpoint: {updateUIForPlayer.lastCheckPointPassed}/{updateUIForPlayer.checkpointCount}";
        uITextWrongDirection.gameObject.SetActive(updateUIForPlayer.WrongDirection);
    }
}
