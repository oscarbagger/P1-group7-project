using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHolder : MonoBehaviour
{
    private int textIndex=-1; // index of text to be displayed on next block. 
    [Multiline]
    public string[] negativeBlockText; // array of text to put on blocks. Written in inspector.

    // returns the next text to be displayed on a block. as long as there are more texts in the array keep picking the next one.
    public string GetNewText()
    {
        if (textIndex+1< negativeBlockText.Length)
        {
            textIndex++;
        }
        return negativeBlockText[textIndex]; 
    }
}
