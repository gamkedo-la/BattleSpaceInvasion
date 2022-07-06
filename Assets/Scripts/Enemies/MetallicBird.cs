using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetallicBird : MonoBehaviour
{
    public GameObject explosion;
    //public Transform target;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    public float t;
    [SerializeField]
    private float speed;
   
      

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
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
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

          

        }
        if (other.tag == "largeLaser")
        {



          
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(3);
            Destroy(other.gameObject);
            Destroy(this.gameObject);




        }

    }


}
