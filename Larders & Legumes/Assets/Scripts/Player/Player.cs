using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //Stamina will essentially act like a timer in most cases, decreasing over time to some degree.
    public float maxStamina = 60f;
    public float currentStamina;
    
    //Reduce Stamina at rate of StaminaReductionValue/StaminaReductionRate
    public float staminaReductionValue = .5f;
    public int staminaReductionRate = 5;
    // If you have already started reducing stamina, we do not want this function to run again until it has completed itself fully,
    // otherwise, the stamina that is reduced will compound
    bool staminaReduction = false;


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
        
        if(Input.GetKeyDown(KeyCode.J))
        {
            RecoverStamina(10);
            Debug.Log(currentStamina);
        }

        ReduceStaminaOverTime(staminaReductionValue, staminaReductionRate);

    }

    public void ReduceStaminaOverTime(float value, int time)
    {
        
        if (!staminaReduction)
        {
            staminaReduction = true;
            StartCoroutine(ReduceStaminaOverTimeCoroutine(value, time));
        }
    }

    IEnumerator ReduceStaminaOverTimeCoroutine(float value, float time)
    {
        float staminaReduced = 0;
        float reducedPerLoop = value / time;
        while(staminaReduced < value)
        {
            Debug.Log(staminaReduced);
            staminaReduced += reducedPerLoop;
            yield return new WaitForSeconds(1f);
        }
        ReduceStamina(staminaReduced);
        staminaReduction = false;
    }

    void TakeDamage (int damage)
    { 
        currentHealth -= damage;
        health.SetValueTo(currentHealth);

        if (health.GetCurrentValue() <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    void Heal (int value)
    {
        if (currentHealth < maxHealth)
        {
            if (currentHealth + value <= maxHealth)
                currentHealth += value;
            else
                currentHealth = maxHealth;

            health.SetValueTo(currentHealth);
        }
        else
            Debug.Log("You're at max health");
    }

    void ReduceStamina (float value)
    {
        currentStamina -= value;
        stamina.SetValueTo(currentStamina);
    }

    void RecoverStamina (float value)
    {
        if (currentStamina < maxStamina)
        {
            if (currentStamina + value <= maxStamina)
                currentStamina += value;
            else
                currentStamina = maxStamina;

            stamina.SetValueTo(currentStamina);
        }
        else
            Debug.Log("You're at max stamina");
    }
}
