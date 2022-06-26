using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    //central variable that will keep track of all the sentences in the current dialog
    //public string[] senteces; // array is just a list of objects, a list of text elements we also have a data type that is much more fitting.
    private Queue<string> sentences; // this works like a lists, its a bit more restrictive. Its a FIFO collection. First in first out. 


    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with" + dialogue.name);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        
            sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
          
            return;
        }

        string sentence = sentences.Dequeue();
        //Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        SceneManager.LoadScene("Mission Log 1");
        Debug.Log("End of conversation.");
       

    }

}
