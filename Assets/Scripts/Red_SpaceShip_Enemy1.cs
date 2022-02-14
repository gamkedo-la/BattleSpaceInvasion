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
    }

    void redSpaceshipMovement()
    {
      
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }
}
