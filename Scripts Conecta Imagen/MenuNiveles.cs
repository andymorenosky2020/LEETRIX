using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void CambiarEscenaPorIndice(int indiceDeLaEscena)
    {
        SceneManager.LoadScene(indiceDeLaEscena);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}

