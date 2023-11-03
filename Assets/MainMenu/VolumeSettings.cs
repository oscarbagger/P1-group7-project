using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    // [SerializeField] attribute is used to make the private variables
    // accessible within the Unity editor without making them public! 
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;

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
            SetVolume();
        } 
    }

    public void SetVolume()
    {
        // Unity will automatically assign Dynamic Float to the function of the slider.
        // The slider and the Audiomixer will now be connected!
        // First, get the slider value
        float volume = musicSlider.value;
        // and then, set the audiomixer value to the sliders value
        audioMixer.SetFloat("volume", volume);
        // to save the players prefered volume settings, we'll make use of the PlayerPref class.
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    // Private method to load the volume settings saved
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetVolume();
    }
}

