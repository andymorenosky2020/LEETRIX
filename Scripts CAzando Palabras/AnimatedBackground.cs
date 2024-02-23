using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedBackground : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSecond = 10.0f;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        image.sprite = frames[index];
    }
}
