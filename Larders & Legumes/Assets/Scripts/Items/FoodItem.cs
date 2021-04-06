using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : Item
{
    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        itemName = "Food Item";
        value = 10;
    }

    public new void Use()
    {
        player.DecreaseHunger(value);
        Destroy(gameObject);
    }
}
