using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_SpaceShip_Enemy1 : MonoBehaviour
{

    private float speed = 5.0f;

    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(13, 4, 0);
        scaleChange = new Vector3(0.6f, 0.6f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scaleChange; // used localScale property to scale object. 
        redSpaceshipMovement();
        if(transform.position.x < -9f)
        {
            float random = Random.Range(-4f, 4f);
            transform.position = new Vector3(8, random, 0);
        }
    }

    void redSpaceshipMovement()
    {
      
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }

    //Add life variable to Red_SpaceShip
    //If redSpaceship is hit by laser once start first fire animation and reduce life variable
    //If redSpaceship is hit twice add additional fire animatino and reduce life of variable.
    // if redSpaceship is hit the third time, destroy and apply explosion animation. 
}
