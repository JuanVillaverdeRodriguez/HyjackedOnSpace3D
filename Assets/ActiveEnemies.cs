using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemies : MonoBehaviour
{
    private GameObject  enemies;
    void Start(){
        enemies = this.gameObject.transform.parent.Find("Enemies").gameObject;
        if(enemies == null)
        {
            Debug.Log("ENEMIES NULL");
            return;
        }
        enemies.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        /*int childs = enemies.transform.childCunt;
        for (int i = 0;i< childs; i++)
        {
            enemies.transform.GetChild(i).GameObject.SetActive(true);
        }*/
        if (collider.gameObject.tag == "Player"){
            enemies.SetActive(true);
        }
    }
}
