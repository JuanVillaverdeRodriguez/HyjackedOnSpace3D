using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenadorCentral : MonoBehaviour, Interactable2
{
    [SerializeField] private string _prompt;
    public GameObject puertaAbierta;
    public GameObject puertaCerrada;
    string interactMode;

    private bool activado;

    public void Start()
    {
        interactMode = "1";
        activado = false;
        puertaAbierta.SetActive(false);
        puertaCerrada.SetActive(true);
    }

    public void Interact(Interactor2 interactor)
    {
        if (activado)
        {
            interactMode = "3";
            puertaAbierta.SetActive(true);
            puertaCerrada.SetActive(false);
        }
    }

    public void activar()
    {
        interactMode = "2";
        activado = true;
    }
    public string InteractPrompt()
    {
        return interactMode;
    }
}
