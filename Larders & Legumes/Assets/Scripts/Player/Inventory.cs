using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    private bool filled = false;

    //DEBUG
    public GameObject itemButton;
    public GameObject UI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject img = Instantiate(itemButton, UI.transform);
            img.transform.SetParent(UI.transform, true);
            Time.timeScale = 0f;
        }
    }

    public void CheckIfFilled()
    {
        int count = 0;

        foreach(bool slot in isFull)
        {
            if (slot) count++;
        }

        if (count == isFull.Length) 
            filled = true;
        else 
            filled = false;
    }

    public bool IsFull()
    {
        return filled;
    }
}
