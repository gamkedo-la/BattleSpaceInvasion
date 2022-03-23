using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update

    private bool shieldActive = false;
    void Start()
    {
        transform.position = Player.currentPos; 
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.currentPos; 
        shieldActive = Player.shieldActive;
        if (shieldActive) 
        {
            gameObject.layer = 0; // default layer
        } 
        else
        {
            gameObject.layer = 3; // invisible debug layer (hardcoded for now)
        } 
        
    }
}
