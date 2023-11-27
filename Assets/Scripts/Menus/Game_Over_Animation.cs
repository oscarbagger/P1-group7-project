using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over_Animation : MonoBehaviour
{
    Animator Animat;
    public bool OverDone;

    // Start is called before the first frame update
    void Start()
    {
        Animat = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (OverDone)
        {
            Animat.SetTrigger("Box_Ball");
        }
        
    }
}
