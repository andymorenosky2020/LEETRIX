using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Final : MonoBehaviour
{
    public void InicioJuego(int numeroDeEscena)
    {
        SceneManager.LoadScene(numeroDeEscena);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
