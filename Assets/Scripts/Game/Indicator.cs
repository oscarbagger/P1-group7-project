using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Indicator : MonoBehaviour
{
    //Array of sprites
    [SerializeField] Sprite[] sprites;
    //The SpriteRenderer the sprites is passed to
    private Image indicator;

    //This can be something else from the StressLevel script
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        SwapSprite();
        index = StressLevel.StressPercentage;
            

        
    }

    //This method changes the sprite when integer named index is changed
    void SwapSprite()
    {

        if (index < 25)
        {
            indicator.sprite = sprites[0];
        }
        else if (index > 25 && index < 50) 
        {
            indicator.sprite = sprites[1];
        }
        else if (index > 50)
        {
            indicator.sprite = sprites[2];
        }
    }
}

