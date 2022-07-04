using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject explosion;
    //public Transform target;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    public float t;
     [SerializeField]
    private float speed;
    private Vector2 movement;
    //[SerializeField]
    // private float attackSpeed;
    // Start is called before the first frame update

    public float degreesPerSec = 180f;
  
    void Start()
    {
        //rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 direction = target.position - transform.position;
        ////Debug.Log(direction);
        ////float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        ////rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;
        Rotate();
    }

    private void Rotate()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float currentRotation = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation + rotAmount));
    }



    void FixedUpdate()
    {
        //MoveBird(movement);
        Move();
    }


    private void Move()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "laser")
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(1);
            Destroy(other);
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            //CameraShake.instance.Shake(100.0f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

            // TODO: Deal damage to player

        }
        if (other.tag == "largeLaser")
        {



            //CameraShake.instance.Shake(100.0f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(3);
            Destroy(other.gameObject);
            Destroy(this.gameObject);


            //Destroy(this.gameObject);

        }

    }




    //void MoveBird(Vector2 direction)
    //{
    //   // transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    //    rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));


    //    //Bird will shoot up
    //    //Remove the bird head and transition to bird launch (either front or back of jet)
    //    //Pick player position at that time and quickly fly toward it.
    //    // remove bird launch and turns to bird attack png.
    //    // add rotation applied to aim at the point picked.
    //    //Bird should only pick that one set of coordinates and fly toward it. Shouldn't continually lock on and follow the player.

    //}
}
