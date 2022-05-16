using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//This script controls the settings menu 
//This script could be added to a pause menu feature

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
