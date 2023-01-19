using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is mainly for the enemies' health and the enemies' animation when damaged.

public class Enemy : MonoBehaviour
{
    // This action is connected to the Score script
    public static Action<int> OnDeath;

    private int _health;
    [SerializeField] private int _initialHealth;
    [SerializeField] private Animator _enemyA;

    private void Awake()
    {
        // The code below is used for the OnDeath action.
        // _initialHealth will be the score gained by the player if the player killed an enemy.
        // So if enemy's health is 100, the player will gain 100 score from killing the enemy.
        _health = _initialHealth;
    }

    public void TakeDamage(int damage)
    {
        // To prevent adding a score more than 1 time after every enemy death.
        if (_health < 0)
        {
            return;
        }

        _health -= damage;

        if (_health > 0)
        {
            _enemyA.SetTrigger("BackToNormal");
        }

        if (_health == 0)
        {
            _enemyA.SetTrigger("dead");
            Destroy(gameObject, 0.5f);
            if (OnDeath != null) OnDeath?.Invoke(_initialHealth);
        }
    }

    public void ForDamageAnimation()
    {
        _enemyA.SetTrigger("damaged");
    }

    public Enemy()
    {

    }
}