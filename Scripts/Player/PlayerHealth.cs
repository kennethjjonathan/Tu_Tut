using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to set the player's health and triggering a game over scene (if player's health is below 0).

public class PlayerHealth : MonoBehaviour
{
    public static Action<int> OnDamaged;
    public static Action OnDeath;

    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;

        OnDamaged?.Invoke(health);

        if (health <= 0)
        {
            Destroy(gameObject, 0.5f);
            OnDeath?.Invoke();
        }
    }

    public PlayerHealth()
    {

    }
}
