using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int maxStamina = 60;
    public int currentStamina;

    public StatBar health;
    public StatBar stamina;

    private void Start()
    {
        currentHealth = maxHealth;
        health.SetStatMax(maxHealth);

        currentStamina = maxStamina;
        stamina.SetStatMax(maxStamina);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            ReduceStamina(10);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            RecoverStamina(10);
        }
    }

    void TakeDamage (int damage)
    { 
        currentHealth -= damage;
        health.SetStat(currentHealth);
    }

    void Heal (int value)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += value;
            health.SetStat(currentHealth);
        }
    }

    void ReduceStamina (int value)
    {
        currentStamina -= value;
        stamina.SetStat(currentStamina);
    }

    void RecoverStamina (int value)
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += value;
            stamina.SetStat(currentStamina);
        }
    }
}
