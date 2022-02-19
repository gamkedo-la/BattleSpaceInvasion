using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PowerUp", order = 1)]
public class Power_Up : ScriptableObject
{
    enum PowerUpCategory
    {
        Speed,
        Weapon
    };

    [SerializeField] PowerUpCategory category;
    [SerializeField] int multiplier = 0;
    [SerializeField] int damage = 0;
    [SerializeField] string sprite;
    [SerializeField] string power_up_name;

}
