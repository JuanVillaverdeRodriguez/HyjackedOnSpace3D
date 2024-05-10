using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{

    public GameObject botonNivel1;
    public GameObject botonNivel2;
    public GameObject botonNivel3;

    private void Start()
    {
        botonNivel1.SetActive(false);
        botonNivel2.SetActive(false);
        botonNivel3.SetActive(false);
    }
    public void Jugar()
    {
        botonNivel1.SetActive(true);
        botonNivel2.SetActive(true);
        botonNivel3.SetActive(true);
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void cargarNivel1()
    {
        Debug.Log("Cargar nivel1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void cargarNivel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void cargarNivel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
