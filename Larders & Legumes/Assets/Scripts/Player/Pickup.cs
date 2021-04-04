using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{

    private Inventory inventory;
    public GameObject itemButton;
    bool itemFound = true;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && itemFound)
        {
            Debug.Log("Found an item");
            AddToInventory();
        }
    }

    void AddToInventory()
    {
        if(!inventory.IsFull())
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    GameObject stowedItem = Instantiate(itemButton, inventory.slots[i].transform);
                    stowedItem.GetComponent<Pickup>().itemFound = false;
                    Debug.Log("Item added to inventory");
                    Destroy(gameObject);
                    inventory.CheckIfFilled();
                    //resume time
                    Time.timeScale = 1f;
                    break;
                }
            }
        }
    }
}
