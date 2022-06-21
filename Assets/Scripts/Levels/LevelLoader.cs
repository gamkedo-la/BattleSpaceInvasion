using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public PauseMenu pause { get; private set; }
    public GameObject pauseGO;
    public Animator transition;
    private bool isPaused;
    public float transitionTime = 1f;


    private void Awake()
    {
        pause = pauseGO.GetComponent<PauseMenu>();
    }

    private void OnEnable()
    {
        //Subscribe to get notified when game is paused
        //This is relevant so if the screen moves on after clicking, then clicking in the pause menu won't count
        pause.Paused += SetPauseStatus;
    }

    private void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isPaused)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
      StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        //Load scene
    }

    private void SetPauseStatus(bool paused)
    {
        isPaused = paused;
    }

    private void OnDisable()
    {
        //Unsubscribe to get notified when game is paused
        pause.Paused -= SetPauseStatus;
    }
}
