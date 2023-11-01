using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Indikator : MonoBehaviour
{
    //Array of sprites
    [SerializeField] Sprite[] sprites;
    //The SpriteRenderer the sprites is passed to
    [SerializeField] SpriteRenderer indikator;

    //This can be something else from the StressLevel script
    [SerializeField] int index;

    // Start is called before the first frame update
    void Start()
    {
        indikator = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SwapSprite();
    }

    //This method changes the sprite when integer named index is changed
    void SwapSprite()
    {
        switch (index)
        {
            case 0:
                indikator.sprite = sprites[0];
                break;
            case 1:
                indikator.sprite = sprites[1];
                break;
            case 2:
                indikator.sprite = sprites[2];
                break;
            default:
                indikator.sprite = sprites[0];
                break;
        }
    }
}

