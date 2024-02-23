using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImage2 : MonoBehaviour
{
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameController2 gameController2;

    public void OnMouseDown()
    {
        if (image_unknown.activeSelf && gameController2.canOpen)
        {
            image_unknown.SetActive(false);
            gameController2.imageOpened(this);
        }
    }

    private int _spriteId;
    public int spriteId
    {
        get
        {
            return _spriteId;
        }
    }

    public void ChangeSprite(int id,Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Close()
    {
        image_unknown.SetActive(true);
    }


}
