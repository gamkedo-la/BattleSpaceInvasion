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

    public void LoadScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
