using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPrincipal : MonoBehaviour
{
    public int indiceDeLaEscenaACargar; 

    public void CambiarEscena()
    {
        SceneManager.LoadScene(indiceDeLaEscenaACargar); // Cargar la escena por su nombre.
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

}
