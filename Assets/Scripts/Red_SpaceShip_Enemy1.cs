using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_SpaceShip_Enemy1 : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 5.0f;
    //private float health = 3f;

    private CameraShake shake;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(13, 4, 0);
        scaleChange = new Vector3(0.6f, 0.6f, 1);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scaleChange; // used localScale property to scale object. 
        redSpaceshipMovement();
        if(transform.position.x < -9f)
        {
            float random = Random.Range(-4f, 4f);
            transform.position = new Vector3(8, random, 0);
        }
    }

    void redSpaceshipMovement()
    {
      
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Add life variable to Red_SpaceShip
        //If redSpaceship is hit by laser once start first fire animation and reduce life variable
        //If redSpaceship is hit twice add additional fire animation and reduce life of variable.
        // if redSpaceship is hit the third time, destroy and apply explosion animation. 
       
        if (other.tag == "laser")
        {
            shake.CamShakeAnimator();
            Instantiate(explosion,transform.position, Quaternion.identity);
           // Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
        if (other.tag == "Player")
        {
          
            Instantiate(explosion, transform.position, Quaternion.identity);
            // TODO: Deal damage to player

            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);

            
            

        }

    }

  
}
