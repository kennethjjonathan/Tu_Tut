using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used for the Score UI.

public class Score : MonoBehaviour
{

    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        Enemy.OnDeath += UpdateScore;
    }

    private void OnDisable()
    {
        Enemy.OnDeath -= UpdateScore;
    }

    private void UpdateScore(int points)
    {
        score += points;
        scoreText.SetText("Score: " + score);
    }

}
