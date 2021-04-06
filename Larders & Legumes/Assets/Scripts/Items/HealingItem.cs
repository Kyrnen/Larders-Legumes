using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : Item
{

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        itemName = "Healing Item";
        value = 10;
    }

    public new void Use()
    {
        player.Heal(value);
        Destroy(gameObject);
    }
}
