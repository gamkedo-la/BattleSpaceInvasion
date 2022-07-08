using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_SpaceShip_Enemy1 : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 5.0f;
    //private float health = 3f;

   
    private Vector3 scaleChange;
    [SerializeField]
    private int redSpaceShipLives = 3;

    //private AudioSource explosionSound;
    [SerializeField] GameObject audioManagerGO;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = audioManagerGO.GetComponent<AudioManager>();
        //explosionSound = GetComponent<AudioSource>();
        transform.position = new Vector3(13, 4, 0);
        scaleChange = new Vector3(0.4f, 0.4f, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scaleChange; // used localScale property to scale object. 
        redSpaceshipMovement();
       if(transform.position.x < -9f)
        {
            float random = Random.Range(-3f, 3f);
            transform.position = new Vector3(8, random, 0);
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
            if (redSpaceShipLives == 0)
            {
                CameraShake.instance.Shake(100.0f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.instance.AddPoints(3);
                //explosionSound.Play();
                PlayAudioClip("Explosion2");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }

        if (other.tag == "largeLaser")
        {


            if (redSpaceShipLives == 0)
            {
                CameraShake.instance.Shake(100.0f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.instance.AddPoints(3);
                Destroy(other.gameObject);
                Destroy(this.gameObject);

            }
            //Destroy(this.gameObject);

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

    public void PlayAudioClip(string sound)
    {
        audioManager.Play(sound);
    }

    public void redSpaceShipDamage()
    {
        redSpaceShipLives--;

        if (redSpaceShipLives <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

   

  
}
