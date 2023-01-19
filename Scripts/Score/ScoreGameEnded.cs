using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* This script is used for the score text in the GameWinningPanel or GameOverPanel.
 * I cannot use the same score text from the GamePanel because the panels are not activcated during gameplay, hence it will not count the score 
 * and will display zero when activated.
 */

public class ScoreGameEnded : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        ScoreBank.OnShareScore += ReceiveScore;
    }

    private void OnDisable()
    {
        ScoreBank.OnShareScore -= ReceiveScore;
    }

    private void ReceiveScore(int score)
    {
        _scoreText.SetText("Score: " + score);
    }
}
