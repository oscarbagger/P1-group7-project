using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHolder : MonoBehaviour
{
    private int textIndex=-1;
    [Multiline]
    public string[] negativeBlockText;

    public string GetNewText()
    {
        if (textIndex< negativeBlockText.Length)
        {
            textIndex++;
        }
        return negativeBlockText[textIndex]; 
    }
}
