using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Settings Scriptable Object
[CreateAssetMenu(fileName = "New Menu", menuName = "Audio")]
public class AudioSO : ScriptableObject 
{
    public Sound[] sounds;
}
