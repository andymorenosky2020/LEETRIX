using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public int indiceEscena;

    public void MenuNiveles()
    {
        SceneManager.LoadScene(indiceEscena);
    }
}
