using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    public void OnClick()
    {
        // Carga la escena principal para reiniciar el juego.
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
