using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueNew : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public string sceneToOpenAfter;
    private bool clickedSoSpeedUp = false;

    public GameObject continueButton;
    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("clicked");
            clickedSoSpeedUp = true;
        }
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

    }

    IEnumerator Type()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Narrarator");
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            if (clickedSoSpeedUp == false) {
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        audioManager.Stop("Narrarator");

    }

    public void NextSentence()
    {
        clickedSoSpeedUp = false;
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            //if dialogue scene dialogue introCharacterStory
            EndDialogue();

            // if dialogue scene dialogue shipDashBoard

            //if dialogue scene is ending story
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        SceneManager.LoadScene(sceneToOpenAfter);
        Debug.Log("End of conversation.");


    }

}
