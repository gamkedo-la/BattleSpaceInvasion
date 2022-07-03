using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

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
            EndDialogue1();

            // if dialogue scene dialogue shipDashBoard

            //if dialogue scene is ending story
        }
    }

    void EndDialogue1()
    {
        //animator.SetBool("IsOpen", false);
        SceneManager.LoadScene("Mission Log 1");
        Debug.Log("End of conversation.");


    }

    void EndDialogue2()
    {
        //animator.SetBool("IsOpen", false);
        SceneManager.LoadScene("Mission Log 2");
        Debug.Log("End of conversation.");


    }
}
