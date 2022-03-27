using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo1 : MonoBehaviour
{

    //CONSTANT VARIABLES
   private float speed = 4.0f;

    //calculation of direction of player
    public Transform player;

    private Rigidbody2D ufo1rb;

    private Vector2 movement;

    private bool shipFacingRight = false;



    // Start is called before the first frame update
    void Start()
    {
        //transform.position= new Vector3(10, 2, 0);
        ufo1rb = this.GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) *  Mathf.Rad2Deg;
        //ufo1rb.rotation = angle;
        direction.Normalize();
        movement = direction;
      
       
        
    }

    private void FixedUpdate()
    {
        Ufo1Movement(movement);
        changeDirection();



    }


    void changeDirection()
    {
        

        if (transform.position.x >= 0)
        {
           // shipFacingRight == false;
            // change rotation (180,0,180)
            Debug.Log("position of is rotation x > 0");
            Vector3 rotationVector = new Vector3(180, 0, 180);
            Quaternion rotation = Quaternion.Euler(rotationVector);
        }
        else
        {
            //shipFacingRight == true;
            //change rotation (0,0,0)
            Debug.Log("position of is rotation x < 0");
            Vector3 rotationVector = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.Euler(rotationVector);
        }
    }



    void Ufo1Movement(Vector2 direction)
    {
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        ufo1rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

      

    }


    void FollowPlayer()
    {

    }
}
