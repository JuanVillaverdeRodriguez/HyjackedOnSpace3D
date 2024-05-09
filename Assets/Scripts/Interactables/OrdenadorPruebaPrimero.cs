using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenadorPruebaPrimero : MonoBehaviour, Interactable2
{
    [SerializeField] private string _prompt;
    public GameObject ordenadorCentralPrimero;
    string interactMode = "2";


    public void Interact(Interactor2 interactor)
    {
        interactMode = "3";
        ordenadorCentralPrimero.GetComponent<OrdenadorCentralPrimero>().activar();
        Debug.Log("Activado el ordenador central");
    }

    public string InteractPrompt()
    {
        return interactMode;
    }
}
