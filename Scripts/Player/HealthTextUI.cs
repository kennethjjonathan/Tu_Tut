using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script is used for the player's health UI.

public class HealthTextUI : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private TextMeshProUGUI healthText;

    private void OnEnable()
    {
        PlayerHealth.OnDamaged += UpdateHealth;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDamaged -= UpdateHealth;
    }

    private void UpdateHealth(int CurrentHealth)
    {
        healthText.SetText("health: " + CurrentHealth);
    }
}
