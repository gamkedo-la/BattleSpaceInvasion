using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    public AudioMixer audioMixer;
    public SettingsSO settings;
    private Scene currentScene;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Start()
    {
        Debug.Log("Sound volume is at: " + (settings.soundSetting * 100) + "%");
        audioMixer.SetFloat("Volume", Mathf.Log10(settings.soundSetting) * 20);
        currentScene = SceneManager.GetActiveScene();
        //Debug.Log(currentScene.name);
        PlayThemeSound();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                FindObjectOfType<AudioManager>().StopAllSounds();
                break;
            default:
                Debug.LogError("Build index invalid");
                break;
        }
    }

    /*
    private void Update()
    {
        //Debug.Log(currentScene.name);
        if (currentScene != SceneManager.GetActiveScene())
        {
            //Debug.Log(currentScene.name);
            currentScene = SceneManager.GetActiveScene();
            FindObjectOfType<AudioManager>().StopAllSounds();
        }
    }
    */

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayThemeSound()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuTheme");
    }
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}