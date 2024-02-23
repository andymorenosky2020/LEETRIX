using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Índice de la nueva escena a la que quieres cambiar
    public int indiceDeLaNuevaEscena;

    // Método llamado cuando se presiona el botón
    public void CambiarEscenaConBoton()
    {
        // Cambiar a la nueva escena por índice
        SceneManager.LoadScene(indiceDeLaNuevaEscena);
    }

    public void Salir()
    {
        Application.Quit();
    }
}

