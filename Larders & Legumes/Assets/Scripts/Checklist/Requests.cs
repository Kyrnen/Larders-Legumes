using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requests
{
    public static string[] potentialItems = { "Item", "Healing Item", "Food Item" };

    public Dictionary<Item, int> CreateRequest(List<Item> items)
    {
        Dictionary<Item, int> request = new Dictionary<Item, int>();
        int r = Random.Range(1, 9);
        for(int i = 0; i <= r; i++)
        {
            Item newItem = items[Random.Range(0, items.Count)];
            if(!request.ContainsKey(newItem))
            {
                request.Add(newItem, 1);
            }
            else
            {
                request[newItem] += 1;
            }
        }

        return request;
    }

    public static Dictionary<string, int> DebugRequest (string[] items)
    {
        Dictionary<string, int> request = new Dictionary<string, int>();
        int r = Random.Range(1, 9);
        for (int i = 0; i <= r; i++)
        {
            string newItem = items[Random.Range(0, items.Length)];
            if (!request.ContainsKey(newItem))
            {
                request.Add(newItem, 1);
            }
            else
            {
                request[newItem] += 1;
            }
        }

        return request;
    }
}
