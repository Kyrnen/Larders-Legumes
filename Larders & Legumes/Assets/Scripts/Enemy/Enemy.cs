using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform cam;
    public GameObject UI;

    public StatBar health;

    int maxHealth = 25;
    public int currentHealth;

    public int attackPower = 10;

    public GameObject[] potentialDrops;

    public Item reward;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        UI = GameObject.FindGameObjectWithTag("UI");
        currentHealth = maxHealth;
        health.SetStatMax(currentHealth);

        reward.itemButton = potentialDrops;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        health.SetValueTo(currentHealth);
    }

    public void Drop()
    {
        reward.GenerateItem();
        Debug.Log("ItemGenerated");
        Destroy(gameObject);
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
    }
}
