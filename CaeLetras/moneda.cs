using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;


public class moneda : MonoBehaviour
{
    GameObject boy;
    GameObject girl;
    Rigidbody2D rbMoneda;
    public Text letraMoneda;
    public Text PalabraFondo;
    public Color colorCorrecto = Color.green;
    
    string[] letrasPosibles = { "A", "B", "C", "D","E", "F", "G", "H", "I", "J",
      "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    string letraAleatoria;
   // public string palabraSolicitada;
    

    Animator saltanina;
    Animator saltanino;
    List<string> letrasDisponibles;
    //private Dictionary<char, bool> letrasPintadas = new Dictionary<char, bool>();
    // private HashSet<char> letrasPintadas = new HashSet<char>();
    private List<char> letrasPintadas = new List<char>();
    AudioSource audioSource;

    private GameManager gameManager;







    private void Awake()
    {
        
        gameManager = FindObjectOfType<GameManager>();

        boy = GameObject.FindGameObjectWithTag("boy");
        saltanino = boy.GetComponent<Animator>();

        girl = GameObject.FindGameObjectWithTag("girl");
        saltanina = girl.GetComponent<Animator>();

        rbMoneda = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    private void Start()
    {
        rbMoneda.velocity = -Vector2.up*4;

        string palabra = gameManager.palabraSolicitada;



        letrasDisponibles = new List<string>(letrasPosibles); // Convertimos el arreglo en una lista
        letrasDisponibles.AddRange(gameManager.palabraSolicitada.ToCharArray().Select(c => c.ToString()));  //palabraSolicitada
       

        if (letrasDisponibles.Count > 0)
         {

             int indiceAleatorio = Random.Range(0, letrasDisponibles.Count);
             letraAleatoria = letrasDisponibles[indiceAleatorio];
             letraMoneda.text =letraAleatoria;
         }
         else
         {
             Debug.LogError("La palabra solicitada está vacía.");
         }

       /* if (letrasDisponibles.Count > 0 && palabrasDisponibles.Count > 0)
        {
            int indicePalabraAleatoria = Random.Range(0, palabrasDisponibles.Count);
            palabraSolicitada = palabrasDisponibles[indicePalabraAleatoria];
            palabrasDisponibles.RemoveAt(indicePalabraAleatoria);

            int indiceAleatorio = Random.Range(0, letrasDisponibles.Count);
            letraAleatoria = letrasDisponibles[indiceAleatorio];
            letraMoneda.text = letraAleatoria;
        }
        else
        {
            Debug.LogError("No hay letras o palabras disponibles.");
        }*/

       










    }

    private void ActualizarPalabraSolicitada()
    {
        //string palabra = PalabraSolicitada.text;
        PalabraFondo.text = "";
        foreach (char letra in gameManager.palabraSolicitada)  //palabraSolicitada
            if (letrasDisponibles.Contains(letra.ToString()))
            {
                PalabraFondo.text += $"<color=#00FF00>{letra}</color>";
            }
            else
            {
                PalabraFondo.text += letra;
            }
        }

      
    private void Update()
    {
        Destroy(gameObject, 3.0f);
    }

    private void OnMouseDown()
    {
        if (gameManager.palabraSolicitada.Contains(letraMoneda.text)) //palabraSolicitada
        {
            
            Destroy(gameObject);
            Debug.Log("¡Letra Correcta! Has destruido la moneda.");
            instanciador2.correcto = true;
            saltanina.SetTrigger("ninaSalta");
            letrasDisponibles.Remove(letraMoneda.text);
            //ActualizarPalabraSolicitada();
            ActualizarColorLetras(Color.green);

            // Reproducir audio
            string nombreArchivo = letraMoneda.text;
            AudioClip audioClip = Resources.Load<AudioClip>(nombreArchivo);

            if (audioClip != null)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
            }
            else
            {
                Debug.LogError("No se encontró el sonido para la letra: " + letraMoneda.text);
            }











        }
        else
        {
            Destroy(gameObject);
            Debug.Log("¡Letra Incorrecta!");
            instanciador2.incorrecto = true;
            saltanino.SetTrigger("saltaboy");
            
        }
    
    }







    private void OnDestroy()
    {
        instanciador2.correcto = false;
        instanciador2.incorrecto = false;
    }

    private void ActualizarColorLetras(Color color)
    {
        GameObject palabraObjeto = GameObject.FindGameObjectWithTag("palabra");
        if (palabraObjeto != null)
        {
            Text PalabraFondo = palabraObjeto.GetComponent<Text>();

            string palabraActual = gameManager.palabraSolicitada;  //palabraSolicitada
            PalabraFondo.text = "";
            string nuevaPalabra = "";

            //List<char> letrasPintadas = new List<char>();
           // List<char> letrasYaPintadas = new List<char>();

            foreach (char letra in palabraActual)
            {
                Debug.Log("Letras Pintadas: " + string.Join(", ", letrasPintadas));
                if (letrasDisponibles.Contains(letra.ToString()) && letraMoneda.text == letra.ToString())
                {
                    Debug.Log(letrasPintadas.ToString());
                    if (!letrasPintadas.Contains(letra))
                     {
                         nuevaPalabra += $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{letra}</color>";
                         letrasPintadas.Add(letra);
                     }
                     else
                     {
                        string colorAnterior = GetColorAnterior(PalabraFondo.text, letra);

                        nuevaPalabra += $"<color=#{colorAnterior}>{letra}</color>";
                        //nuevaPalabra += $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{letra}</color>";
                    }


                    /*nuevaPalabra += $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{letra}</color>";
                    letrasPintadas.Add(letra);
                    letrasYaPintadas.Add(letra);*/

                    Debug.Log("Letra coloreada: " + letra);
                }
                else
                {
                    nuevaPalabra += letra;
                }
            }
            PalabraFondo.text = nuevaPalabra;

            Debug.Log("Palabra Actualizada: " + PalabraFondo.text);
        }
    }

    private string GetColorAnterior(string texto, char letra)
    {
        string pattern = $"<color=#([A-Fa-f0-9]{{6}})>{letra}</color>";
        Match match = Regex.Match(texto, pattern);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        return ColorUtility.ToHtmlStringRGB(colorCorrecto);
    }

}