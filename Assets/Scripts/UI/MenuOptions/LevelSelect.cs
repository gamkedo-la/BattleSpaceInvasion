using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script controls the level select in the main menu
//The reason I didn't put this in the MainMenuScript is because this script could potentially be used somewhere else in the game
//For example, the player could have the ability to level select from the pause menu of any screen

public class LevelSelect : MonoBehaviour
{
    [SerializeField] string levelName;
    private PauseMenu pause;
    private GameObject sceneManagerGO;

    private void Start()
    {
        sceneManagerGO = GameObject.FindGameObjectWithTag("SceneManager");
        if(sceneManagerGO != null)
            pause = sceneManagerGO.GetComponent<PauseMenu>(); 
    }

    public void LoadScene()
    {
        if(pause != null)
            pause.Resume();
        ScoreManager.ResetScore();
        SceneManager.LoadScene(levelName);
    }
}
