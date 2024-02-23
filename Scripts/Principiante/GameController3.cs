using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 2;

    private int paresEncontrados = 0;
    public int totalDePares = 4;

    public const float Xspace = 5f;
    public const float Yspace = 6f;

    [SerializeField] private MainImage3 startObject;
    [SerializeField] private Sprite[] images;

    [SerializeField] private AudioClip[] audiosDeParejas;
    public GameObject[] pantallas;
    private AudioSource audioSource;

    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        pantallas[0].SetActive(false);
        pantallas[1].SetActive(false);

        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
        locations = Randomiser(locations);

        audioSource = GetComponent<AudioSource>();

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImage3 gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImage3;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);

            }


        }

    }

    private MainImage3 firstOpen;
    private MainImage3 secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptsText;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(MainImage3 startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());

        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            score++;
            scoreText.text = "Puntos: " + score;

            int parejaIndex = firstOpen.spriteId;

            // Reproducir el audio de la pareja coincidente.
            audioSource.clip = audiosDeParejas[parejaIndex];
            audioSource.Play();

            paresEncontrados++; // Incrementa el contador de pares encontrados.

            if (paresEncontrados == totalDePares)
            {
                // Se han encontrado todos los pares, activa la pantalla 1.
                pantallas[1].SetActive(true);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attemptsText.text = "Intentos: " + attempts;

        if (attempts > 8) // Verifica si se alcanzó el límite de intentos.
        {
            //pantallas[0].SetActive(true); // Carga la pantalla adicional.
            Restart();
        }

        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}