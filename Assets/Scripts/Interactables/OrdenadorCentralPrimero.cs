using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenadorCentralPrimero : MonoBehaviour, Interactable2
{
    [SerializeField] private string _prompt;
    public GameObject puertaAbierta1;
    public GameObject puertaCerrada1;
    public GameObject puertaAbierta2;
    public GameObject puertaCerrada2;
    public GameObject puertaAbierta3;
    public GameObject puertaCerrada3;
    public GameObject puertaAbierta4;
    public GameObject puertaCerrada4;
    
    public string interactMode;

    private bool activado;

    public void Start()
    {
        interactMode = "1";
        activado = false;
        puertaAbierta1.SetActive(false);
        puertaCerrada1.SetActive(true);
        puertaAbierta2.SetActive(false);
        puertaCerrada2.SetActive(true);
        puertaAbierta3.SetActive(false);
        puertaCerrada3.SetActive(true);
        puertaAbierta4.SetActive(false);
        puertaCerrada4.SetActive(true);
    }

    public void Interact(Interactor2 interactor)
    {
        if (activado)
        {
            interactMode = "3";
            puertaAbierta1.SetActive(true);
            puertaCerrada1.SetActive(false);
            puertaAbierta2.SetActive(true);
            puertaCerrada2.SetActive(false);
            puertaAbierta3.SetActive(true);
            puertaCerrada3.SetActive(false);
            puertaAbierta4.SetActive(true);
            puertaCerrada4.SetActive(false);
        }
    }

    public void activar()
    {
        activado = true;
        interactMode = "2";
    }
    public string InteractPrompt()
    {
        return interactMode;
    }
}
