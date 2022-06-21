using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public event Action<bool> Paused = delegate { };

    [SerializeField] string mainMenu;

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject[] pauseMenuPanels;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(gameIsPaused);
            if(gameIsPaused)
            {
                Debug.Log("Resume");
                Resume();
            }
            else
            {
                Debug.Log("Pause");
                Pause();
            }
        }
    }

    public void Resume()
    {
        foreach(GameObject gameObject in pauseMenuPanels)
        {
            gameObject.SetActive(false);
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Paused.Invoke(gameIsPaused);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Paused.Invoke(gameIsPaused);
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(mainMenu);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT! (Won't do anything while in Unity editor)");
        Application.Quit();
    }
}
