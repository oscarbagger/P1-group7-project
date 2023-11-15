using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Indicator : MonoBehaviour
{
    //Array of sprites
    [SerializeField] Sprite[] sprites;
    //The SpriteRenderer the sprites is passed to
    [SerializeField] SpriteRenderer indicator;

    //This can be something else from the StressLevel script
    [SerializeField] int index;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponent<SpriteRenderer>();
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







        /*switch (index)
        {
            case 0:
                indicator.sprite = sprites[0];
                break;
            case 1:
                indicator.sprite = sprites[1];
                break;
            case 2:
                indicator.sprite = sprites[2];
                break;
            default:
                indicator.sprite = sprites[0];
                break;
        }*/
    }
}

