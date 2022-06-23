using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
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
        Debug.Log("Starting conversation with" + dialogue.name);
    }
}
