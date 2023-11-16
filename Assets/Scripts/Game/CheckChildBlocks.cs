using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// this script checks if any squares in a block has been destroyed by line clears and removes text or the parent object accordingly.
public class CheckChildBlocks : MonoBehaviour
{
    private int startingNumberofChildren;
    void Start()
    {
        startingNumberofChildren = transform.childCount; // count number of child objects
    }

    void Update()
    {
        if (transform.childCount!=startingNumberofChildren) // check if number of child objects is no longer the same as from the start
        {
            // if any child object has a text component, destroy it
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
