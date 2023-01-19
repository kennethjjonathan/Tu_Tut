using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used for the Status UI (Counting down or "Kill the enemies!").

public class Status : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private GameObject statusTextObject;

    private void OnEnable()
    {
        WaveSpawner.OnStatus += UpdateStatus;
    }

    private void OnDisable()
    {
        WaveSpawner.OnStatus -= UpdateStatus;
    }

    private void UpdateStatus(float waveCountdown)
    {
        if (waveCountdown > 0)
        {
            statusText.SetText("Countdown: " + waveCountdown.ToString("0"));
        }
        else if (waveCountdown <= 0)
        {
            statusText.SetText("Kill the enemies!");
        }
    }
}
