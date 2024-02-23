using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class boton : MonoBehaviour
{
    GameObject boy;
    GameObject girl;
    Rigidbody2D rbBoton;
    public TMP_Text letraBoton;
    string[] letrasPosibles = { "A", "B", "C", "D","E", "F", "G", "H", "I", "J",
      "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    string letraAleatoria;
    Animator saltanina;
    Animator saltanino;
    AudioSource audioSource;
  
    

    



    private void Awake()
    {
        boy = GameObject.FindGameObjectWithTag("boy");
        saltanino = boy.GetComponent<Animator>();

        girl = GameObject.FindGameObjectWithTag("girl");
        saltanina = girl.GetComponent<Animator>();

        rbBoton = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }




    private void Start()
    {
        rbBoton.velocity = -Vector2.up * 4;
        int indiceAleatorio = Random.Range(0, letrasPosibles.Length);
        letraAleatoria = letrasPosibles[indiceAleatorio];
        letraBoton.text = letraAleatoria;

       /* string nombreArchivo = letraAleatoria;
        AudioClip audioClip = Resources.Load<AudioClip>(nombreArchivo);

        if(audioClip !=null)
        {
            audioSource.clip = audioClip;
        }
        else
        {
            Debug.LogError("No se encontró el sonido para la letra: " + letraAleatoria);
        }

        audioSource.Play();*/



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }

        if (collision.CompareTag("boy"))
        {
            saltanino.Play("playerBoySalta");
            instanciador.consonante = true;
            

        }

        if (collision.CompareTag("girl"))
        {
            saltanina.Play("playerGirlSalta");
            instanciador.vocal = true;
            

        }
    }

    private void Update()
    {
        Destroy(gameObject, 3.0f);

    }

    private void OnMouseDown()
    {
       

        if (letraAleatoria == "A" || letraAleatoria == "E" || letraAleatoria == "I" || letraAleatoria == "O" || letraAleatoria == "U")
        {
            Debug.Log("Es Vocal");
            instanciador.vocal = true;
            saltanina.SetTrigger("ninaSalta");

            string nombreArchivo = letraBoton.text;
            AudioClip audioClip = Resources.Load<AudioClip>(nombreArchivo);

            if (audioClip != null)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
            }
            else
            {
                Debug.LogError("No se encontró el sonido para la letra: " + letraBoton.text);
            }


        }
        else
        {
            Debug.Log("Es Consonante");
            instanciador.consonante = true;
            saltanino.SetTrigger("saltaboy");
            

        }

        
        Destroy(gameObject);
        Debug.Log("Has iniciado MouseDown ");
    }

    private void OnDestroy()
    {
        instanciador.vocal = false;
        instanciador.consonante = false;
    }

}

   

    




