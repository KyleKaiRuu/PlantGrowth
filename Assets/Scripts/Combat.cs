using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public GameObject enemy;
    private Health enemyHealth;
    private Combat enemyCombat;
    private CharacterStats enemyCharacterStats;

    private CharacterStats characterStats;

    public bool playersTurn = true;
    public bool defending;

    public List<Button> buttons;

    private void Awake()
    {
        if (enemy.TryGetComponent(out Health _h))
        {
            enemyHealth = _h;
        }
        if (enemy.TryGetComponent(out Combat _c))
        {
            enemyCombat = _c;
        }
        if(enemy.TryGetComponent(out CharacterStats _cs))
        {
            enemyCharacterStats = _cs;
        }
        if (gameObject.TryGetComponent(out CharacterStats _pcs))
        {
            characterStats = _pcs;
        }
    }

    private void Update()
    {
        if (!playersTurn)
        {
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
        }
        else
        {
            foreach (Button button in buttons)
            {
                button.interactable = true;
            }
        }
    }

    public void Attack(int dmg)
    {
        int critical = 1;
        int critRand = Random.Range(0, 100);
        if (critRand < characterStats.criticalRate)
        {
            Debug.Log("Critical Hit!");
            critical = 2;
        }
        int dmgBeforeBonus = dmg + (characterStats.attack / enemyCharacterStats.defense);
        float tempTest = Mathf.Round(((float)characterStats.bonuses / 100) * dmgBeforeBonus);
        int dmgAfterBonus = (int)(dmgBeforeBonus + Mathf.Round(((float)characterStats.bonuses / 100) * dmgBeforeBonus)) * critical;

        if (enemyCombat.defending)
        {
            enemyHealth.health -= Mathf.RoundToInt(dmgAfterBonus * 0.50f);
            enemyCombat.defending = false;
        }
        else
        {
            enemyHealth.health -= dmgAfterBonus;
        }
        playersTurn = !playersTurn;
        enemyCombat.playersTurn = !enemyCombat.playersTurn;
    }

    public void Defend()
    {
        defending = true;
        playersTurn = !playersTurn;
        enemyCombat.playersTurn = !enemyCombat.playersTurn;
    }

    public void Items()
    {
        //Inventory

    }

    public void Escape()
    {
        //Leave battle, will lower animal species trust and kill an animal

    }
}
