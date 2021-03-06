using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_SpaceShip_Enemy1_Left : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 5.0f;
    //private float health = 3f;


    private Vector3 scaleChange;
    [SerializeField]
    private int redSpaceShipLeftLives = 3;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(-8f, 72.46f, 0);
        scaleChange = new Vector3(0.4f, 0.4f, 1);

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scaleChange; // used localScale property to scale object. 
        redSpaceshipMovement();
        if (transform.position.x > 9f)
        {
            float random = Random.Range(-3f, 3f);
            transform.position = new Vector3(-8, random, 0);
        }
    }

    void redSpaceshipMovement()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Add life variable to Red_SpaceShip - Ok
        //If redSpaceship is hit by laser once start first fire animation and reduce life variable
        //If redSpaceship is hit twice add additional fire animation and reduce life of variable.
        // if redSpaceship is hit the third time, destroy and apply explosion animation. 

        if (other.tag == "laser")
        {
            if (redSpaceShipLeftLives == 0)
            {
                CameraShake.instance.Shake(100.0f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                ScoreManager.instance.AddPoints(2);
            }
        }

        if (other.tag == "largeLaser")
        {
            if (redSpaceShipLeftLives == 0)
            {
                CameraShake.instance.Shake(100.0f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                ScoreManager.instance.AddPoints(2);

            }
        }

        if (other.tag == "Player")
        {
            CameraShake.instance.Shake(100.0f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            // TODO: Deal damage to player

            Player player = other.transform.GetComponent<Player>();
            if (player != null) // perform a null check error handling. 
            {
                player.PlayerDamage();
            }
            Destroy(this.gameObject);

        }

    }

    public void redSpaceShipDamage()
    {
        redSpaceShipLeftLives--;

        if (redSpaceShipLeftLives <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
