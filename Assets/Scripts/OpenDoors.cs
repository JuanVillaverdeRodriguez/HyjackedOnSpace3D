using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour, Interactable
{
    [SerializeField] private string _prompt;

    public string InteractPrompt => _prompt;
    private float rate = 9f;
    private float count = 0.0f;
    private bool opening = false;
    private GameObject enemies;

    private void Awake()
    {
        enemies = GameObject.Find("Mapita/Pasillo3/Enemies");
    }
    private void Update()
    {
        if(opening)
        {
            open();
        }
    }
    public void Interact(Interactor interactor)
    {
        if (count == 0){
            opening = true;
        }
        enemies.SetActive(true);
        /*GameObject[] triggers = GameObject.FindGameObjectsWithTag("TriggerSala3");
        if (triggers == null)
        {
            Debug.LogError("NO SE ENCONTRARON TRIGGERS");
        }
        else
        {
            foreach(GameObject trigger in triggers)
            {
                trigger.SetActive(false);
            }
        }*/
        Debug.Log("ABRIENDO PUERTAS");
    }
    private void open()
    {
        if(count < 20f){
            GameObject[] doors;
            GameObject[] ExitDoors;
            doors = GameObject.FindGameObjectsWithTag("Door");
            ExitDoors = GameObject.FindGameObjectsWithTag("ExitDoor");
            if(doors == null)
            {
                Debug.Log("SIN PUERTAS");
            }
            foreach(GameObject door in doors)
            {
                Debug.Log("Trigger enter door");
                door.transform.Translate(Vector3.up * Time.deltaTime * rate);
            }
            foreach(GameObject door in ExitDoors)
            {
                Debug.Log("Trigger enter door");
                door.transform.Translate(Vector3.up * Time.deltaTime * rate);
            }
            count += Time.deltaTime * rate;
        }else{
            count = 0.0f;
            opening = false;
        }
    }
}
