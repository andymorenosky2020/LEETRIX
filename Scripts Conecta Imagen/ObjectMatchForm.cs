using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]


public class ObjectMatchForm : MonoBehaviour
{
    [SerializeField] private int matchId;
    private AudioSource audioSource;

    private void Start()
    {
        // Asegúrate de tener un AudioSource adjunto al objeto
        audioSource = GetComponent<AudioSource>();

        // Cargar el audio correspondiente desde la carpeta Resources
        AudioClip audioClip = Resources.Load<AudioClip>("Audio/audio_" + matchId);

        // Asignar el audio al AudioSource
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
        else
        {
            Debug.LogError("Audio clip not found for matchId: " + matchId);
        }
    }

    public int Get_ID()
    {
        return matchId;
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

}
