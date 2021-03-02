using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutionList;
    public Dropdown resDropdown;
    public AudioMixer mixer;
    int currResIndex = 0;
    public Slider volumeSlider;
    private void Start()
    {
        resolutionList = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();
        

        for(int i = 0; i < resolutionList.Length; i++)
        {
            string option = resolutionList[i].width + " x " + resolutionList[i].height;
            resOptions.Add(option);

            if(resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height)
            {
                currResIndex = i;
            }
            
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currResIndex;
        resDropdown.RefreshShownValue();

        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.75f);
    }
    public void SetVolume(float value)
    {
        mixer.SetFloat("volume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("volume", value);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutionList[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
