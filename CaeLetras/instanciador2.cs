using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instanciador2 : MonoBehaviour
{
    public GameObject[] monedasFinales; 
    public GameObject[] pantallas;
    
    public GameObject moneda;
    public Transform izquierda;
    public Transform derecha;
    public Slider barraIzquierda;
    public Slider barraDerecha;
    public static bool correcto;
    public  static bool incorrecto;
    public int maxDerecha;
    public int maxIzquierda;

    bool instanciaBotones;
    CircleCollider2D[] coliderFinal;

    void Start()
    {
        pantallas[0].SetActive(false);
        pantallas[1].SetActive(false);
        instanciaBotones= true;
        barraDerecha.maxValue = maxDerecha;
        barraIzquierda.maxValue = maxIzquierda;
        correcto = false;
        incorrecto = false;
        barraIzquierda.value = 0;
        barraDerecha.value = 0;
        StartCoroutine(caeBotones());
    }

    

    IEnumerator caeBotones()
    {
        while (instanciaBotones == true)
        {
            
            for (int a = 1; a <= 12; a++)
            {


                float posicionAleatoria = Random.Range(izquierda.transform.position.x, derecha.transform.position.x);
                Instantiate(moneda, new Vector3(posicionAleatoria, izquierda.transform.position.y, 0), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);

            }
            yield return new WaitForSeconds(3.0f);
        } 
    }

     private void Update()
     {
        if(barraDerecha.value == barraDerecha.maxValue)
        {
            monedasFinales = GameObject.FindGameObjectsWithTag("moneda");
            for (int i= 0; i<= monedasFinales.Length-1; i++)
            {
               CircleCollider2D circulos = monedasFinales[i].GetComponent<CircleCollider2D>();
                circulos.enabled = false;
            }
            pantallas[1].SetActive(true);
            instanciaBotones = false;
        }

        if (barraIzquierda.value == barraIzquierda.maxValue)
        {
            monedasFinales = GameObject.FindGameObjectsWithTag("moneda");
            for (int i = 0; i <= monedasFinales.Length - 1; i++)
            {
                CircleCollider2D circulos = monedasFinales[i].GetComponent<CircleCollider2D>();
                circulos.enabled = false;
            }
            pantallas[0].SetActive(true);
            instanciaBotones = false;
        }

        if (correcto == true)
        {
            barraDerecha.value++;
        }

        if (incorrecto == true)
        {
            barraIzquierda.value++;
        }
     }

  
}
