using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    // The void needs a value to set to our slider, so we choose a float because we want a value with decimal places.
    // Whenever we move our slider, this function (SetVolume) will be called. 

    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        // Unity will automatically assign Dynamic Float to the function of the slider.
        // The slider and the Audiomixer will now be connected!
        audioMixer.SetFloat("volume", volume);
    }


    // Graphics Settings
    // uses int to reference the element that is chosen in the dropdown menu (0, 1, 2)
    public void SetQuality(int qualityIndex)
    {
        // Access our quality settings, and will now automatically set our quality access to the element that we chose.
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
