using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    StatBar health;

    int maxHealth = 25;
    int currentHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentHealth = maxHealth;

    }

    //Enemy should: Constantly face the player after spawning
    //              attack the player when they are directly in front of them
    //              Take Damage when hit
}
