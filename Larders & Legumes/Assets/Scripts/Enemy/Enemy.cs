using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    StatBar health;

    int maxHealth = 25;
    int currentHealth;

    public Transform cam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentHealth = maxHealth;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        health.SetValueTo(currentHealth);

        if (health.GetCurrentValue() <= 0)
        {
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

    public void Heal(int value)
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

    //Enemy should: Constantly face the player after spawning
    //              attack the player when they are directly in front of them
    //              Take Damage when hit
}
