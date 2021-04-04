using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    //DEBUG
    public GameObject[] itemButton;
    public GameObject UI;

    public void GenerateItem()
    {
        GameObject img = Instantiate(itemButton[UnityEngine.Random.Range(0, itemButton.Length)], UI.transform);
        img.transform.SetParent(UI.transform, true);
        Time.timeScale = 0f;
    }
}
