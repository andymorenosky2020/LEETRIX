using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    public void MenuNivel()
    {
        SceneManager.LoadScene(1);
    }

    public void Ayuda()
    {
        SceneManager.LoadScene(21);
    }

}
