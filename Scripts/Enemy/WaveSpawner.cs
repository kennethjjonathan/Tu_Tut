using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to create the waves of enemies'

public class WaveSpawner : MonoBehaviour
{
    // This action is connected to the Pause Menu script.
    public static Action OnWinning;
    // This action is connected to the Status script.
    public static Action<float> OnStatus;

    [SerializeField] private enum SpawnState { SPAWNING, WAITING, COUNTING };
    
    [System.Serializable]
    private class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
    }

    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 5f;

    [SerializeField] private float waveCountdown;

    [SerializeField] private float searchCountdown = 1f;

    private int waveCount;

    [SerializeField]
    private SpawnState state = SpawnState.COUNTING;

    void Awake()
    {
        waveCount = 0;
    }

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        state = SpawnState.COUNTING;
    }

    void Update()
    {
        if (waveCount < waves.Length)
        {
            //Start Countdown
            if (state == SpawnState.COUNTING)
            {
                OnStatus?.Invoke(waveCountdown);
                
                //To check the waveCountdown time
                if (waveCountdown <= 0)
                {
                    state = SpawnState.SPAWNING;
                }
                else if (waveCountdown > 0)
                {
                    waveCountdown -= Time.deltaTime;
                }
            }
            //Start Spawning
            else if (state == SpawnState.SPAWNING)
            {
                BeginWave();
                state = SpawnState.WAITING;
            }
            //To wait for the player to finish the enemies in a wave
            else if (state == SpawnState.WAITING)
            {
                //Check for enemies
                searchCountdown -= Time.deltaTime;
                if (searchCountdown <= 0)
                {
                    EnemyIsAlive();
                    if (EnemyIsAlive() == false)
                    {
                        //Begin a new round
                        waveCountdown = timeBetweenWaves;
                        waveCount++;
                        state = SpawnState.COUNTING;
                    }
                    else if (EnemyIsAlive() == true)
                    {
                        searchCountdown = 1f;
                    }
                }
            }
        }
        else
        {
            OnWinning?.Invoke();
            return;
        }
    }

    public bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }

    void BeginWave()
    {
        Wave _wave = waves[waveCount];

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
        }
    }
}


