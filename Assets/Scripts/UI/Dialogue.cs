using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{

    // we are using this dialogue class as an object that we can pass to our dialogue manager. 
    // this class will host all the information that we need about a single dialogue. We wont need monobehaviour because we don't want it to sit on a script.

    public string name;

    [TextArea(3,100)] // first parameter states the minimum, and second one is the maximum

    public string[] sentences;

}
