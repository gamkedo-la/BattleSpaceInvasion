using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//This script controls the settings menu 
//This script could be added to a pause menu feature

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;
    public SettingsSO settings;

    private void Start()
    {
        if(audioSlider == null)
        {
            this.enabled = false;
            return;
        }
        audioSlider.value = settings.soundSetting;
        audioSlider.onValueChanged.AddListener(UpdateSlider);
    }

    private void UpdateSlider(float soundChange)
    {
        settings.soundSetting = audioSlider.value;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}