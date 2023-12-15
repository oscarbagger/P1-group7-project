using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour

// For creation and coding of the volume sliders, the YouTube tutorial
// “Unity AUDIO Volume Settings Menu Tutorial” published by the channel ReHope Games was used (ReHope Games, 2020).

{
    // [SerializeField] attribute is used to make the private variables
    // accessible within the Unity editor without making them public! 
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        // using playerPref, we can save the players volume setting, and load the preference
        // when starting up the game again.

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            // if the volume was different than default, then load this change
            LoadVolume();
        }
        else
        {
            // if nothing has changed, simply load the volume normally.
            SetMusicVolume();
            SetSFXVolume();
        } 
    }


    // Unity will automatically assign Dynamic Float to the function of the slider.
    // The slider and the Audiomixer will now be connected!
    public void SetMusicVolume()
    {
        // First, get the slider value
        float volume = musicSlider.value;
        // and then, set the audiomixer value to the sliders value
        audioMixer.SetFloat("musicParam", Mathf.Log10(volume)*20);
        // to save the players prefered volume settings, we'll make use of the PlayerPref class.
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        // First, get the slider value
        float volume = SFXSlider.value;
        // and then, set the audiomixer value to the sliders value
        audioMixer.SetFloat("SFXParam", Mathf.Log10(volume) * 20);
        // to save the players prefered volume settings, we'll make use of the PlayerPref class.
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    // Private method to load the volume settings saved
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
}

