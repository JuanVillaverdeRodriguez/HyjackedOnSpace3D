using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMKitchen : MonoBehaviour, Interactable
{
    public string InteractPrompt => throw new System.NotImplementedException();

    public GameObject ray1;
    public GameObject ray2;

    public void Interact(Interactor interactor)
    {
        Debug.Log("Cortando la luz");
        ray1.SetActive(false);
        ray2.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
