using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo1 : MonoBehaviour
{

    //CONSTANT VARIABLES
    private float speed = 4.0f;

    //


    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(10, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Ufo1Movement();
        if (transform.position.x < 4.9f)
        {
          // float random = Random.Range(-2.5f, 7f);

            transform.position = new Vector3(0, -2.5f, 0);
        }

        
    }


    void Ufo1Movement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    void FollowPlayer()
    {

    }
}
