//Código de DropSlot
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class DropSlot : MonoBehaviour, IDropHandler
{
    //public Level level;
    public AudioClip levelCompleteAudio;
    private AudioSource audioSource;
    public  GameObject item;
    public GameObject expectedItem;
    void Start()
    {
        GameObject audioController = GameObject.Find("AudioController");
        audioSource = audioController.GetComponent<AudioSource>();
        levelCompleteAudio = audioSource.clip;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item && DragHandler.itemDragging == expectedItem)
        {
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
            item.GetComponent<DragHandler>().SetOriginalPosition(transform.position);
            CheckAllDropSlotsOccupied();

        }
    }

    private IEnumerator WaitAndLoadNextLevel()
    {
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(levelCompleteAudio);

        yield return new WaitForSeconds(2f);
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            item = null;
        }
       
        
    }

    private void CheckAllDropSlotsOccupied()
    {
        DropSlot[] dropSlots = FindObjectsOfType<DropSlot>();
        bool allOccupied = true;

        foreach (DropSlot dropSlot in dropSlots)
        {
            if (!dropSlot.item)
            {
                allOccupied = false;
                break;
            }
        }

        if (allOccupied)
        {
           
            StartCoroutine(WaitAndLoadNextLevel());
        }
    }


}

