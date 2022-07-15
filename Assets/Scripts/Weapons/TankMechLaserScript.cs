using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMechLaserScript : MonoBehaviour
{

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * 4.0f;
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

            Player player = other.transform.GetComponent<Player>();
            if (player != null) // perform a null check error handling. 
            {
                player.PlayerDamage();
            }

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
