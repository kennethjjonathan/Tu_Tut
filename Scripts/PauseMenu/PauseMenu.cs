using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls most scene management, including the pause scene, the in game scene, and the game winning scene.

public class PauseMenu : MonoBehaviour
{
    // This action is used to inform the Score script to share the score to the GameOverPanel or GameWinningPanel.
    public static Action OnEndGame;

    private bool GamePaused;
    private bool GameOver = false;
    private bool GameCompleted = false;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject GameWinningPanel;

    private void OnEnable()
    {
        PlayerHealth.OnDeath += SetGameOver;
        WaveSpawner.OnWinning += SetGameWinning;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDeath -= SetGameOver;
        WaveSpawner.OnWinning -= SetGameWinning;

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else if (!GamePaused)
            {
                Pause();
            }
        }

        if (GameOver == true)
        {
            EndGame();
            Debug.Log("Game Over");
            GameOver = false;
            OnEndGame?.Invoke();
        }

        if (GameCompleted == true)
        {
            WinGame();
            Debug.Log("Game Completed");
            GameCompleted = false;
            OnEndGame?.Invoke();
        }
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        GamePanel.SetActive(true);
    }

    private void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        GamePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    private void EndGame()
    {
        GameOverPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    private void SetGameOver()
    {
        GameOver = true;
    }

    private void WinGame()
    {
        GameWinningPanel.SetActive(true);
        GamePanel.SetActive(false);
    }

    private void SetGameWinning()
    {
        GameCompleted = true;
    }
}


