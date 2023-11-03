using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void PlayGame()
    {
        // Shifts the MainMenu Screen (Scene 0) to the Game scene (Scene 1)
        // It simply adds +1 for the current scene loaded, as the order of the scenes is 0, 1
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        // Coroutines can be used to execute a piece of code across multiple frames.
        //Like two scenes in unity!
    }

    // when using Coroutines, instead of void, we use IEnumerator
    // this is because we want to give time for the animation to play, before transition
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play transition animation
        transition.SetTrigger("Start");

        // Wait for animation to stop playing, or wait for a certain ammount of seconds
        yield return new WaitForSeconds(transitionTime);

        // load the scene
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        // Just a simple command to quit the game. The debug is just to show it will close in Unity
        Debug.Log("Quit!");
        Application.Quit();
    }


    void Start()
    {
        
    }
}
