using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    #region Variables
    public AudioMixer audiomixer;
    public TMP_Dropdown resolutiondropdown;
    public Slider volumel;
    Resolution[] resolutions;
    #endregion
    #region Methods
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutiondropdown.ClearOptions();

        List<string> options = new List<string>();

        int currresoIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (Screen.currentResolution.height == resolutions[i].height &&  Screen.currentResolution.width == resolutions[i].width)
            {
                currresoIndex = i;
            }
        }
        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currresoIndex;
        resolutiondropdown.RefreshShownValue();
    }

    public void Setvolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
        volumel.value = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Setfullscreen(bool isvalue)
    {
        Screen.fullScreen = isvalue;
    }

    public void SetResolution(int resoIndex)
    {
        Resolution resolution = resolutions[resoIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion
}
