using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaScript : MonoBehaviour
{

    public static bool Pausado = false;
    public GameObject MenuPausa;

    public void Start()
    {
        MenuPausa.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Debug.Log("Escape Detectado");
            if (!Pausado)
            {
                Pausar();
            }
            else
            {
                Continuar();
            }
        }
    }

    public void Continuar()

    {
        MenuPausa.SetActive(false);
        Pausado = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Pausado=true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
