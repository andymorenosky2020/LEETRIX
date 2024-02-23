using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteButton : MonoBehaviour
{
    public void OnClick()
    {
        // Obtiene el número de la escena actual y le suma uno para avanzar al siguiente nivel.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Carga la escena del siguiente nivel.
        SceneManager.LoadScene(nextSceneIndex);
    }
}
