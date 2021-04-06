using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected Player player;
    public string itemName;
    protected float value;

    //DEBUG
    public GameObject[] itemButton;
    public GameObject UI;

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        itemName = "Item";
    }

    public void GenerateItem()
    {
        GameObject img = Instantiate(itemButton[UnityEngine.Random.Range(0, itemButton.Length)], UI.transform);
        img.transform.SetParent(UI.transform, true);
        Time.timeScale = 0f;
    }

    public void Use() { }
}
