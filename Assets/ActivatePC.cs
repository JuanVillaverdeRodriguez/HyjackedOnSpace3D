using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePC : MonoBehaviour
{
    private GameObject pc;
    private GameObject[] enemies;
    void Start()
    {
        pc = GameObject.Find("PCsala3");
        pc.SetActive(false);
        enemies = GameObject.FindGameObjectsWithTag("EnemieSala3");;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("EnemieSala3");
        Debug.Log(enemies.Length);
        if(enemies.Length != 0)
        {
            Debug.Log("NOT NULL");
            return;
        }
        Debug.Log("NULL");
        pc.SetActive(true);
    }
}
