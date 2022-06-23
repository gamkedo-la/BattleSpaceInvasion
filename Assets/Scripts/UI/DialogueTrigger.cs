using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // This script is going to sit on an object.
    // It will allow us to trigger a new dialogue, lets drag this to the test button. 
    // Start is called before the first frame update
    
    public Dialogue dialogue; // this is the class we created as a C# script

    public void TriggerDialogue (){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

   
}
