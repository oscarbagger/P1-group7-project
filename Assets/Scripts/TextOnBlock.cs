using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOnBlock : MonoBehaviour
{
    private TMP_Text myText;
    private TextHolder textList;
    // Start is called before the first frame update
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
