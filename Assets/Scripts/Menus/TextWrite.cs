using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWrite : MonoBehaviour
{
    [SerializeField] private TMP_Text textToWrite;
    [SerializeField] private float timePerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText());
    }
    private IEnumerator WriteText()
    {
        int textLength = textToWrite.text.Length;
        string myText = textToWrite.text;
        textToWrite.text = myText.Insert(0, "<alpha=#00>");
        int i = 0;
        while (i<textLength)
        {
            textToWrite.text=myText.Insert(i, "<alpha=#00>");
            yield return new WaitForSeconds(timePerCharacter);
            i++;
        }

    }
}
