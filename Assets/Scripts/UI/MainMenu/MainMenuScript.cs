using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
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
}
