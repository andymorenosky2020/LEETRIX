using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    public void OnClick()
    {
        // Carga la escena principal para reiniciar el juego.
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}

