using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;
    public Transform playerReference;
    public Transform doorReference;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        if (playerReference.position.x > doorReference.position.x)
        {

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            //SceneManager.LoadScene("MotherShip");
            Debug.Log("Load next scene");
        }
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        //transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        //Load scene
    }

}
