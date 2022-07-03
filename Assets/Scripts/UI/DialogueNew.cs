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

    public GameObject continueButton;
    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
       
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
