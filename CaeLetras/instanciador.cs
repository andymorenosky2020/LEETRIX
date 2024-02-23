using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instanciador : MonoBehaviour
{
    public GameObject[] pantallas;
    public GameObject[] botonesFinales;
    public GameObject boton;
    public Transform izquierda;
    public Transform derecha;
    public Slider barraIzquierda;
    public Slider barraDerecha;
    public  static bool vocal;
    public  static bool consonante;
    public int maxDerecha;
    public int maxIzquierda;
    public Text puntajeVocal;
    public Text puntajeConsonante;
    int a;
    int b;
    public static bool haTerminadoJuego;
    bool instanciaBotones;
    CircleCollider2D[] coliderFinal;

    

    void Start()
    {
        pantallas[0].SetActive(false);
        pantallas[1].SetActive(false);
        instanciaBotones= true;
        a = 0;
        b = 0;
        puntajeVocal.text = a.ToString();
        puntajeConsonante.text = b.ToString();
        barraDerecha.maxValue = maxDerecha;
        barraIzquierda.maxValue = maxIzquierda;
        vocal = false;
        consonante= false;

        barraIzquierda.value = 0;
        barraDerecha.value = 0;
        StartCoroutine(caeLetras());
        
    }
    

    IEnumerator caeLetras()
    {
        while (instanciaBotones == true)
        {

            for (int a = 1; a <= 10; a++)
            {

                float posicionAleatoria = Random.Range(izquierda.transform.position.x, derecha.transform.position.x);
                GameObject botonClonado = Instantiate(boton, new Vector3(posicionAleatoria, izquierda.transform.position.y, 0), Quaternion.identity);
                botonClonado.AddComponent<AudioSource>(); // Agregar componente AudioSource al objeto clonado


                yield return new WaitForSeconds(1.0f);


            }
            yield return new WaitForSeconds(3.0f);

        }
    }

    private void Update()
    {
        if (barraDerecha.value == barraDerecha.maxValue)
        {
            botonesFinales = GameObject.FindGameObjectsWithTag("boton");
            for (int i =0; i<= botonesFinales.Length - 1; i++){
               CircleCollider2D  circulos = botonesFinales[i].GetComponent<CircleCollider2D>();
                circulos.enabled = false;
            }
            pantallas[1].SetActive(true);
            instanciaBotones = false;
        }

        if (barraIzquierda.value == barraIzquierda.maxValue)
        {
            botonesFinales = GameObject.FindGameObjectsWithTag("boton");
            for (int i = 0; i <= botonesFinales.Length - 1; i++)
            {
                CircleCollider2D circulos = botonesFinales[i].GetComponent<CircleCollider2D>();
                circulos.enabled = false;
            }
            pantallas[0].SetActive(true);
            instanciaBotones=false;
        }

        if (vocal == true)
        {
            barraDerecha.value++;
            puntajeVocal.text = barraDerecha.value.ToString();
            vocal = false;
        }

        if(consonante== true)
        {
            barraIzquierda.value++;
            puntajeConsonante.text = barraIzquierda.value.ToString();
            consonante = false;
        }
    }

    
    
}
