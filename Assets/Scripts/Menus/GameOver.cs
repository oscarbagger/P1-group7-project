using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    //Start is called before the first frame update
    AudioManager Audio;
    private void Awake()
    {
        Audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void ResetTheGame()
    {
        //When we press the Restart Button, it will go back to start
        SceneManager.LoadScene(3);
        print("The button is working");
        Audio.Transition();
    }

    public void BackToMenu()
    {
        //When we press the MainMenu button, it goes back to the main menu
        SceneManager.LoadScene(1);
        print("The button is working");
        Audio.MenuMusic();
    }
}
