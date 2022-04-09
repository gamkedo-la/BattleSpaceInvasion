using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PowerUp", order = 1)]
public class Power_Up : ScriptableObject
{
    public enum PowerUpCategory
    {
        Speed,
        Weapon
    };

    public PowerUpCategory category;
    public int multiplier = 0;
    public int damage = 0;
    public Sprite sprite;
    public GameObject weapon_prefab;
    public string power_up_name;

}
