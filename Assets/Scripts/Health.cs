using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public Text healthText;

    private CharacterStats characterStats;

    private void Awake()
    {
        if(TryGetComponent(out CharacterStats _cs))
        {
            characterStats = _cs;
        }
        health = characterStats.baseHealth;
    }

    private void Update()
    {
        healthText.text = "Health: " + health.ToString();
        if (health < 0)
        {
            health = 0;
        }
        if (health > characterStats.baseHealth)
        {
            health = characterStats.baseHealth;
        }
    }
}
