using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(AudioSource))] // Asegúrate de tener un AudioSource adjunto al objeto

public class ObjectMatchingGame : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int matchId;
    private bool isDragging;
    private Vector3 endPoint;
    private ObjectMatchForm objectMatchForm;
    // [SerializeField] private TextMesh scoreText;

   /* public GameObject[] pantallas;


    public int totalMatches; // El número total de emparejamientos en el juego
    private int completedMatches;
   */





    private void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;


       // pantallas[0].SetActive(false);

       // completedMatches = 0;





    }



    private void Update()

    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                lineRenderer.SetPosition(0, mousePosition);
            }
        }
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            lineRenderer.SetPosition(1, mousePosition);
            endPoint = mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {

            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(endPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.TryGetComponent(out objectMatchForm) && matchId == objectMatchForm.Get_ID())
            {
                Debug.Log("Correct Form");
                objectMatchForm.PlayAudio();  // Reproducir el audio asociado
                this.enabled = false;

                /*completedMatches++; // Incrementa el contador de emparejamientos completados

                // Verifica si se han completado todos los emparejamientos
                if (completedMatches == totalMatches)
                {
                    pantallas[0].SetActive(true); // Activa la pantalla deseada
                }*/

            }
            else
            {
                lineRenderer.positionCount = 0;
            }
            lineRenderer.positionCount = 2;

          
        }






    }

 




}


