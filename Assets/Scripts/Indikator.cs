using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Indikator : MonoBehaviour

{
    public Sprite[] spriteList;
    SpriteRenderer indikator;

    //[SerializeField]SpriteRenderer indikator;
    // Start is called before the first frame update
    void Start()

    {

        indikator = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))

        {
            if (indikator.sprite == spriteList[0])
            {
                indikator.sprite = spriteList[1];
            }
            else if (indikator.sprite == spriteList[1])
            {
                indikator.sprite = spriteList[2];

            }
            else
            {
                indikator.sprite = spriteList[0];
            }
        }

      
        
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            if (indikator.color == Color.red)
            {


                indikator.color = Color.green;

            }
            else if (indikator.color == Color.green)
            {
                indikator.color = Color.yellow;
            }



            else
            {
                indikator.color = Color.red;
            }
        }
        
    }

       /*if(Input.GetKeyDown(KeyCode.O))
        {
            indikator.color = Color.yellow;

        }
       if(Input.GetKeyDown(KeyCode.I))
        {
            indikator.color = Color.red;
        }

       if(Input.GetKeyDown(KeyCode.P))
        {

            
        }*/
    }

    
}

