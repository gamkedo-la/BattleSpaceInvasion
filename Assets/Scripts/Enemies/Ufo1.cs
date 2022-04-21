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
    [SerializeField]
    private int ufo1Lives;

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
            //Debug.Log("position of is rotation x > 0");
            Vector3 rotationVector = new Vector3(180, 0, 180);
            Quaternion rotation = Quaternion.Euler(rotationVector);
        }
        else
        {
            //shipFacingRight == true;
            //change rotation (0,0,0)
            //Debug.Log("position of is rotation x < 0");
            Vector3 rotationVector = new Vector3(0, 0, 0);
            Quaternion rotation = Quaternion.Euler(rotationVector);
        }
    }



    void Ufo1Movement(Vector2 direction)
    {
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        ufo1rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

      

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "laser")
        {


            if (ufo1Lives == 0)
            {
                //CameraShake.instance.Shake(100.0f);
                //Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.instance.AddPoints(3);
                Destroy(other.gameObject);
                Destroy(this.gameObject);

            }
            //Destroy(this.gameObject);

        }

        if (other.tag == "Player")
        {
            //CameraShake.instance.Shake(100.0f);
            //Instantiate(explosion, transform.position, Quaternion.identity);
            // TODO: Deal damage to player

            Player player = other.transform.GetComponent<Player>();
            if (player != null) // perform a null check error handling. 
            {
                player.PlayerDamage();
            }
            Destroy(this.gameObject);

        }
    }

    public void ufo1Damage()
    {
        ufo1Lives--;

        if (ufo1Lives <= 0)
        {
            //Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }



}
