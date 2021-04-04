using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    private Player player;
    float value = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Use()
    {
        player.DecreaseHunger(value);
        Destroy(gameObject);
    }
}
