using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetTheGame()
    {
        //When we press the Restart Button, it will go back to start
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working");
    }

    public void BackToMenu()
    {
        //When we press the MainMenu button, it goes back to the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working");
    }
}
