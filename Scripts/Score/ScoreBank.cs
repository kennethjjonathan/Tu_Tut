using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The ScoreBank script is used to store the score, and then share it to the GameWinningPanel or GameOverPanel.
 * The ScoreBank script is attached to the Canvas game object, hence it can share the score without being disabled first.
 */

public class ScoreBank : MonoBehaviour
{
    public static Action<int> OnShareScore;

    [SerializeField] private bool _gameEnded = false;
    [SerializeField] private int _score;

    private void OnEnable()
    {
        Enemy.OnDeath += UpdateScore;
        PauseMenu.OnEndGame += ShareScore;
    }

    private void OnDisable()
    {
        Enemy.OnDeath -= UpdateScore;
        PauseMenu.OnEndGame -= ShareScore;
    }

    private void Update()
    {
        if (_gameEnded == true)
        {
            OnShareScore?.Invoke(_score);
            _gameEnded = false;
        }
    }

    private void UpdateScore(int points)
    {
        _score += points;
    }

    private void ShareScore()
    {
        _gameEnded = true;
    }
}
