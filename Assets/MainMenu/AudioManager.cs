using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    // This is just the layout for the Audio Manager
    // Creating the places where we can drag n' drop the clips in unity
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    // can add as many adioclips as we want to our manager
    [Header("--- Audio Clip ---")]
    public AudioClip background;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;
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
        musicSource.clip = background;
        musicSource.Play();
        
    }

    // this method takes the audioclip as a parameter
          // - basícally, we make the value from the mixer editable through script
    public void PlaySFX(AudioClip clip)
    {
        // We use PlayOneShot so we can play multiple sound effects at once, without having to wait for the sound to end.
        SFXSource.PlayOneShot(clip);
    }
}
