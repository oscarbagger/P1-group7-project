using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWrite : MonoBehaviour
{
    [SerializeField] private TMP_Text textToWrite;
    [SerializeField] private float timePerCharacter; // time between each new text character being shown
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText()); // start writing out text
    }
    private IEnumerator WriteText()
    {
        int textLength = textToWrite.text.Length; // get length of chosen text
        string myText = textToWrite.text; // make a copy of the text to manipulate for later
        textToWrite.text = myText.Insert(0, "<alpha=#00>"); // set text invisible by inserting <alpha> attribute into start of the text
        int i = 0;
        // insert the <alpha> attribute to a new place each time, revealing a new character of the text, until everything is visible.
        while (i<textLength)
        {
            textToWrite.text=myText.Insert(i, "<alpha=#00>"); 
            yield return new WaitForSeconds(timePerCharacter); // delay
            i++;
        }

    }
}
