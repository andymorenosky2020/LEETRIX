using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImage3 : MonoBehaviour
{
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameController3 gameController3;

    public void OnMouseDown()
    {
        if (image_unknown.activeSelf && gameController3.canOpen)
        {
            image_unknown.SetActive(false);
            gameController3.imageOpened(this);
        }
    }

    private int _spriteId;

    public int spriteId
    {
        get { return _spriteId; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Close()
    {
        image_unknown.SetActive(true);

    }
}
