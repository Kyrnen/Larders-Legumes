using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    public StatBar health;

    int maxHealth = 25;
    int currentHealth;

    public Transform cam;

    public GameObject[] potentialDrops;
    public GameObject UI;

    public Drops reward;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        UI = GameObject.FindGameObjectWithTag("UI");

        currentHealth = maxHealth;
        health.SetStatMax(currentHealth);

        reward.itemButton = potentialDrops;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
        }
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
            reward.GenerateItem();
            Debug.Log("ItemGenerated");
            Destroy(gameObject);
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

    //Enemy should: attack the player when they are directly in front of them
}
