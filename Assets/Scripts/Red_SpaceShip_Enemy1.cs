using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_SpaceShip_Enemy1 : MonoBehaviour
{

    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(9, 4, 0);
    }

    // Update is called once per frame
    void Update()
    {

        redSpaceshipMovement();
    }

    void redSpaceshipMovement()
    {
      
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }
}
