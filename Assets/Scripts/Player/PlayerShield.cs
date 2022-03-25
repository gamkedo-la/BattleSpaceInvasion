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
            transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * 360.0f);
        } 
        else
        {
            gameObject.layer = 3; // invisible debug layer (hardcoded for now)
        } 
        
    }
}
