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
    public GameObject[] itemButton;
    public GameObject UI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject img = Instantiate(itemButton[UnityEngine.Random.Range(0, itemButton.Length)], UI.transform);
            img.transform.SetParent(UI.transform, true);
            Time.timeScale = 0f;
        }
    }

}
