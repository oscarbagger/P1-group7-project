using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour

// For creation and coding of the Audio Manager the YouTube tutorial
// “How to Add MUSIC and SOUND EFFECTS to a Game in Unity | Unity 2D Platformer Tutorial #16”
// published by the channel Rehope Games was used (Rehope Games, 2023). 

{
    // This is just the layout for the Audio Manager
    // Creating the places where we can drag n' drop the clips in unity
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    // can add as many adioclips as we want to our manager
    [Header("--- Audio Clip ---")]
    public AudioClip Background_MainMenu;
    public AudioClip Background_Game;
    public AudioClip Background_GameOver;
    public AudioClip Move_Block;
    public AudioClip Rotate_Block;
    public AudioClip HardDrop_Block;
    public AudioClip sfx4;
    public AudioClip sfx5;


    // to avoid multiple audiomanagers to be spawned when loading new scenes, we will use
    // we will create an instance for our managaer script
    public static AudioManager Instance;

    private void Awake()
    {
        // if this instance has not been created before, then dont detroy it :>
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // if there already is an audio Manager, then bye-bye to the duplicated.
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        // when game is opened, start the background music!
        musicSource.clip = Background_MainMenu;
        musicSource.Play();
        
    }
    public void MenuMusic() //Play main menu music when called
    {

        musicSource.clip = Background_MainMenu;
        musicSource.Play();

    }

    public void Transition() //Play main game music when called
    {

        musicSource.clip = Background_Game;
        musicSource.Play();

    }

    public void Gameover() //Play game over music when called
    {
            musicSource.clip = Background_GameOver;
            musicSource.PlayDelayed(1);
            
    }

    // this method takes the audioclip as a parameter
    // - basícally, we make the value from the mixer editable through script
    public void PlaySFX(AudioClip clip)
    {
        // We use PlayOneShot so we can play multiple sound effects at once, without having to wait for the sound to end.
        SFXSource.PlayOneShot(clip);

    }
}
