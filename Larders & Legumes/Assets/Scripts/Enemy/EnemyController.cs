using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public Player player;

    public bool hasAttacked = false;

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>().GetComponent<Enemy>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    public void DealDamage(int attack)
    {
        player.TakeDamage(attack);
    }

}
