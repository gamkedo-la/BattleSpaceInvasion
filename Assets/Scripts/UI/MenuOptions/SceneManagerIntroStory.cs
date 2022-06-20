using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerIntroStory : MonoBehaviour
{
    [SerializeField] GameObject audioManagerGO;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = audioManagerGO.GetComponent<AudioManager>();
        audioManager.gameObject.GetComponent<AudioManager>().Play("MechSound2");
    }

    private void OnDisable()
    {
        if (audioManager != null)
            audioManager.gameObject.GetComponent<AudioManager>().Stop("MechSound2");
    }
}
