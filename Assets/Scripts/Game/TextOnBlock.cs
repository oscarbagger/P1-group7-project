using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// this script puts the text on the negative blocks, pulling them from the textholder list of text.
public class TextOnBlock : MonoBehaviour
{
    private TMP_Text myText; // text on the block
    private TextHolder textList; // reference to script with the list of texts
    void Awake()
    {
        myText = GetComponentInChildren<TextMeshPro>(); // get textmesh component from child gameobject
        textList = GameObject.Find("TextManager").GetComponent<TextHolder>(); // get reference to textholder
        SetBlockText(textList.GetNewText()); // get text from textholders list of texts
    }
    // set new text on block
    public void SetBlockText(string text)
    {
        myText.text = text;
    }
}
