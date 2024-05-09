using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class UiInteractibles : MonoBehaviour
{
    public GameObject panelDesactivado;
    public GameObject panelActivado;
    public GameObject panelActivo;
    public bool activo;


    private void Start()
    {
        DesactivarUi();
    }
    public void DesactivarUi()
    {
        panelDesactivado.SetActive(false);
        panelActivado.SetActive(false);
        panelActivo.SetActive(false);
        activo = false;
    }

    public void TerminalDesactivado()
    {
        panelDesactivado.SetActive(true);
        panelActivado.SetActive(false);
        panelActivo.SetActive(false);
    }

    public void TerminalActivado()
    {
        panelDesactivado.SetActive(false);
        panelActivado.SetActive(true);
        panelActivo.SetActive(false);
    }

    public void TerminalActivo()
    {
        panelDesactivado.SetActive(false);
        panelActivado.SetActive(false);
        panelActivo.SetActive(true);
    }

    public void activarUi(string mode)
    {
        if (mode == "1")
        {
            TerminalDesactivado();
        }
        else if (mode == "2")
        {
            TerminalActivado();
        }
        else if (mode == "3")
        {
            TerminalActivo();
        }
        activo = true;
    }

}
