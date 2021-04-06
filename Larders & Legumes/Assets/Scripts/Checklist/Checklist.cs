using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    Inventory inventory;
    Dictionary<string, int> request;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        request = Requests.DebugRequest(Requests.potentialItems);
        //foreach (KeyValuePair<string, int> kvp in request)
        //{
        //    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        //    Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        //}
    }
}
