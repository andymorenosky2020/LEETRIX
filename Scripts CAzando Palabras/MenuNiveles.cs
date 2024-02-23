using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
