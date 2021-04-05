using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //Hunger will essentially act like a timer in most cases, increasing over time to some degree.
    public float maxHunger = 120f;
    public float currentHunger;
    
    //Reduce Hunger at rate of hungerValue/hungerRate
    public float hungerValue = 1f;
    public int hungerRate = 5;
    // If you have already started increasing hunger, we do not want this function to run again until it has completed itself fully,
    // otherwise, the hunger that is reduced will compound
    bool hungerRising = false;


    public StatBar health;
    public StatBar hunger;

    public int attackPower = 5;

    private void Start()
    {
        currentHealth = maxHealth;
        health.SetStatMax(maxHealth);

        currentHunger = 0f;
        hunger.SetBaseHunger(maxHunger);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(20);
        }

        IncreaseHungerOverTime(hungerValue, hungerRate);

    }

    public void IncreaseHungerOverTime(float value, int time)
    {
        
        if (!hungerRising)
        {
            hungerRising = true;
            StartCoroutine(IncreaseHungerOverTimeCoroutine(value, time));
        }
    }

    IEnumerator IncreaseHungerOverTimeCoroutine(float value, float time)
    {
        float hungerIncreased = 0;
        float reducedPerLoop = value / time;
        while(hungerIncreased < value)
        {
            Debug.Log(hungerIncreased);
            hungerIncreased += reducedPerLoop;
            yield return new WaitForSeconds(1f);
        }
        IncreaseHunger(hungerIncreased);
        hungerRising = false;
    }

    void TakeDamage (int damage)
    { 
        currentHealth -= damage;
        health.SetValueTo(currentHealth);

        if (health.GetCurrentValue() <= 0)
        {
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

    public void Heal (int value)
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

    public void DecreaseHunger (float value)
    {
        if (currentHunger == 0)
            Debug.Log("Not hungry right now");
        else
        {
            if (currentHunger - value >= 0)
                currentHunger -= value;
            else
                currentHunger = 0;

            hunger.SetValueTo(currentHunger);
        }
       

    }

    void IncreaseHunger(float value)
    {

        if (currentHunger + value <= maxHunger)
            currentHunger += value;
        else
            currentHunger = maxHunger;

        hunger.SetValueTo(currentHunger);

    }
}
