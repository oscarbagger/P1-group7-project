using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckChildBlocks : MonoBehaviour
{
    private int startingNumberofChildren;
    // Start is called before the first frame update
    void Start()
    {
        startingNumberofChildren = transform.childCount;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount!=startingNumberofChildren)
        {
            foreach (Transform children in transform)
            {
                if (children.GetComponent<TextMeshPro>()!=null)
                {
                    Destroy(children.gameObject);
                }
            }
        }
        // if all blocks/childs are gone, remove self. 
        if (transform.childCount==0)
        {
            Destroy(this.gameObject);
        }
    } 
}
