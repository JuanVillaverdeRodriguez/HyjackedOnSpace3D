using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoors : MonoBehaviour
{
    private float translate = -10f;
    private float rate = -9f;
    private float count = 0.0f;
    private bool closing = false;
    private void Update()
    {
        if(closing)
        {
            close();
        }
    }
    private void close()
    {
        if(count > -10f){
            GameObject[] doors;
            doors = GameObject.FindGameObjectsWithTag("Door");
            if(doors == null)
            {
                Debug.Log("SIN PUERTAS");
            }
            foreach(GameObject door in doors)
            {
                Debug.Log("Trigger enter door");
                door.transform.Translate(Vector3.up * Time.deltaTime * rate);
            }
            count += Time.deltaTime * rate;
        }else{
            count = 0.0f;
            closing = false;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        closing = true;
    }
}
