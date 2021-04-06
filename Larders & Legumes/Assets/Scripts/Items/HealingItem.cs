using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    Player player;
    int value = 10;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Use()
    {
        player.Heal(value);
        Destroy(gameObject);
    }
}
