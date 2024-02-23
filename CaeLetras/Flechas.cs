using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flechas : MonoBehaviour
{
   public void NextLevel()
    {
        int siguienteIndice = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(siguienteIndice);
    }

    public void LastLevel()
    {
        int siguienteIndice = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(siguienteIndice);
    }
}
