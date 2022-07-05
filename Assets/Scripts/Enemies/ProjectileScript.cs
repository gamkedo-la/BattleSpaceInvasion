using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject shotPrefab;
    public GameObject laserSpawnPoint;
    private float speed = 2.0f;
    //private float health = 3f;

    
    private Vector3 scaleChange;
    [SerializeField]
    private int spaceshipLives = 3;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector3(13, 4, 0);
        scaleChange = new Vector3(0.5f, 0.5f, 1);
        StartCoroutine(AutoFire());

    }
    IEnumerator AutoFire() {
        while (true) {
            yield return new WaitForSeconds(0.25f);
            GameObject shotGO = GameObject.Instantiate(shotPrefab) as GameObject;
            shotGO.transform.position = laserSpawnPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scaleChange; // used localScale property to scale object. 
        SpaceshipMovement();
        if(transform.position.x < -9f)
        {
            float random = Random.Range(-4f, 4f);
            transform.position = new Vector3(8, random, 0);
        }
    }

    void SpaceshipMovement()
    {
      
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        //Add life variable to Red_SpaceShip - Ok
        //If redSpaceship is hit by laser once start first fire animation and reduce life variable
        //If redSpaceship is hit twice add additional fire animation and reduce life of variable.
        // if redSpaceship is hit the third time, destroy and apply explosion animation. 
       
        if (other.tag == "laser")
        {
            CameraShake.instance.Shake(50.0f);
            SpaceShipDamage();
            if (spaceshipLives == 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.instance.AddPoints(3);
                //explosionSound.Play();
                Destroy(other.gameObject);
                Destroy(this.gameObject);

            }
            //Destroy(this.gameObject);

        }
        
        if (other.tag == "Player")
        {
          
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

    public void SpaceShipDamage()
    {
        spaceshipLives--;

        if (spaceshipLives < 1)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

   

  
}
