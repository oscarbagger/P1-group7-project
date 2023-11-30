using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Variable that will reference our dropdown in unity
    // and then the array itself for the different options!
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        
        // depending on the computer resolutions can vary, so we clear the currents options
        // and then go and replace the options to the computers defaults
        resolutionDropdown.ClearOptions();

        // As the AddOptions function cant work with arrays but only strings, we make a List.
        // we then loop through then loop through each element in our array
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            // create a string which displays our resolutions
            // basically adding the "width x lenght" of the resolutions to the dropdown
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Makes sure that the computers current res is the default in the game.
            // this is done by comparing the computers widthxheight to the games.
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        // when we're done looping through, we add the resolutions to our dropdown      
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
    }


    // When you choose a new resolution from the dropdown it updates.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Res set");
    }

    // Graphics Settings
    // uses int to reference the element that is chosen in the dropdown menu (0, 1, 2)
    public void SetQuality(int qualityIndex)
    {
        // Access our quality settings, and will now automatically set our quality access to the element that we chose.
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("quality set");
    }

    // The method for the toggle button to set the fullscreen!
    // The method is going to take in a boolean because the toggle will either be true or false
    public void SetFullscreen(bool isFullscreen)
    {
        // it will now set our Fullscreen value to whatever our toggle is
        
        Screen.fullScreen = isFullscreen;
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Debug.Log("changed screen");

        // A simple if-else statement, if it is not fullscren, set fullscreen, if it is, then set as windowed
        //if (isFullscreen) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        //else Screen.fullScreenMode = FullScreenMode.Windowed;
        //Debug.Log("changed screen");

    
        

    }


}
