using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenadorPrueba : MonoBehaviour, Interactable2
{
    [SerializeField] private string _prompt;
    public GameObject ordenadorCentral;

    string interactMode = "2";

    public void Interact(Interactor2 interactor)
    {
        interactMode = "3";
        ordenadorCentral.GetComponent<OrdenadorCentral>().activar();
    }
    public string InteractPrompt()
    {
        return interactMode;
    }
}
