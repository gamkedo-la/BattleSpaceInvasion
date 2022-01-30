using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        jetMovement();
    }

    void jetMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * speed * Time.deltaTime);
        
        if ( transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        } else if(transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
            
        
    }
}

