using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToSceneChange : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    private bool pressed = false;
    [SerializeField] private Animator transition;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !pressed)
        {
            StartCoroutine(LoadLevel(sceneIndex));
            pressed = true;
        }

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play transition animation
        transition.SetTrigger("Transis");

        // Wait for animation to stop playing, or wait for a certain ammount of seconds
        yield return new WaitForSeconds(1);

        // load the scene
        SceneManager.LoadScene(levelIndex);
    }
}
