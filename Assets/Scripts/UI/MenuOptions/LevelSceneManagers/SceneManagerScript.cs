using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject audioManagerGO;
    private AudioManager audioManager;
    [SerializeField] string[] playThisSound;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = audioManagerGO.GetComponent<AudioManager>();
        foreach(string s in playThisSound)
        {
            audioManager.gameObject.GetComponent<AudioManager>().Play(s);
        }
    }

    private void OnDisable()
    {
        foreach(string s in playThisSound)
        {
            if (audioManager != null)
            {
                audioManager.gameObject.GetComponent<AudioManager>().Stop(s);
            }
        }


    }
}
