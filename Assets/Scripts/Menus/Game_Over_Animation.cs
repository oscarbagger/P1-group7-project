using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Over_Animation : MonoBehaviour
{
    //write to the animator
    Animator Animat;
    public bool OverDone;

    // get animator component
    void Start()
    {
        Animat = GetComponent<Animator>(); 
    }

    // start transition if "Overdone" is true
    void Update()
    {
        if (OverDone)
        {
            Animat.SetTrigger("Transis");
        }
        
    }
}
