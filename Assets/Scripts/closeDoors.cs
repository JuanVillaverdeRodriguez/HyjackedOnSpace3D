using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoors : MonoBehaviour
{
    private float rate = -9f;
    private float count = 0.0f;
    private bool closing = false;
    private GameObject enemies;

    void Start(){
        enemies = GameObject.Find("Mapita/Sala3/EnemiesSala3");
        if(enemies == null)
        {
            Debug.Log("ENEMIES NULL");
            return;
        }
        enemies.SetActive(false);
    }
    private void Update()
    {
        if(closing)
        {
            close();
        }
    }
    private void close()
    {
        if(count > -20f){
            GameObject[] doors;
            doors = GameObject.FindGameObjectsWithTag("Door");
            if(doors == null)
            {
                Debug.Log("SIN PUERTAS");
            }
            foreach(GameObject door in doors)
            {
                door.transform.Translate(Vector3.up * Time.deltaTime * rate);
            }
            count += Time.deltaTime * rate;
        }else{
            Debug.Log("Deactivating");
            this.gameObject.SetActive(false);
            GameObject door = GameObject.Find("TriggerDoors2");
            if(door != null){
                door.SetActive(false);
            }
            count = 0.0f;
            closing = false;
        }
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
            closing = true;
            Debug.Log("TRIGGER ENTER");
        }
    }
}
