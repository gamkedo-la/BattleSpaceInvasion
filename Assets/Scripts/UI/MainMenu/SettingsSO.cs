using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Settings Scriptable Object
[CreateAssetMenu(fileName = "New Menu", menuName = "Settings")]
public class SettingsSO : ScriptableObject
{
    public float soundSetting;
}