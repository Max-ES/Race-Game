using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uITextCurrentLap;
    [SerializeField] private TextMeshProUGUI uITextCurrentTime;
    [SerializeField] private TextMeshProUGUI uITextLastLap;
    [SerializeField] private TextMeshProUGUI uITextBestLap;
    [SerializeField] private TextMeshProUGUI uITextCheckpoint;
    [SerializeField] private TextMeshProUGUI uITextWrongDirection;

    public Player updateUIForPlayer;

    private void Update()
    {
        uITextCurrentLap.text = $"Runde: {updateUIForPlayer.currentLap}";
        uITextCurrentTime.text = $"Zeit: {updateUIForPlayer.CurrentLapTime}s";
        uITextLastLap.text = $"Letzte Rundenzeit: {updateUIForPlayer.LastLapTime}s";
        uITextBestLap.text = $"Bestzeit: {updateUIForPlayer.BestLapTime}s";
        uITextCheckpoint.text =
            $"Checkpoint: {updateUIForPlayer.lastCheckPointPassed}/{updateUIForPlayer.checkpointCount}";
        uITextWrongDirection.gameObject.SetActive(updateUIForPlayer.WrongDirection);
    }
}