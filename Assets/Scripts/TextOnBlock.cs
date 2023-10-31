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
        myText = GetComponentInChildren<TextMeshPro>();
        textList = GameObject.Find("TextManager").GetComponent<TextHolder>();
        UpdateBlockText("");
    }
    public void UpdateBlockText(string text)
    {
        myText.text = text;
    }
}
