using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // �ndice de la nueva escena a la que quieres cambiar
    public int indiceDeLaNuevaEscena;

    // M�todo llamado cuando se presiona el bot�n
    public void CambiarEscenaConBoton()
    {
        // Cambiar a la nueva escena por �ndice
        SceneManager.LoadScene(indiceDeLaNuevaEscena);
    }

    public void Salir()
    {
        Application.Quit();
    }
}

