using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] SettingsSO settings;
    
    private AudioManager audioManager;

    private void Start()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(settings.soundSetting) * 20);
        Debug.Log("Sound volume is at: " + (settings.soundSetting * 100) + "%");

        audioManager = AudioManager.instance;
        PlayThemeSound();
    }

    public void LoadGame()
    {
        ScoreManager.ResetScore(); // prevents score from saving after finishing game. 
        SceneManager.LoadScene(1);// main game scene intro story
    }

    public void QuitGame()
    {
        Debug.Log("QUIT! (Won't do anything while in Unity editor)");
        Application.Quit();
    }

    public void PlayThemeSound()
    {
        audioManager.gameObject.GetComponent<AudioManager>().Play("MainMenuTheme");
    }

    private void OnDisable()
    {
        if(audioManager != null)
            audioManager.gameObject.GetComponent<AudioManager>().Stop("MainMenuTheme");
    }
}
