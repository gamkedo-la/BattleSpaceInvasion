using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunglePlanetBossWeapon : MonoBehaviour
{
    public GameObject explosion;
    public GameObject shotPrefab;
    private static Transform topMarker;
    private static Transform bottomMarker;
    private float verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (topMarker == null)
        {
            GameObject topEdgeGO = GameObject.Find("ScreenTop");
            topMarker = topEdgeGO.transform;

            GameObject bottomEdgeGO = GameObject.Find("ScreenBottom");
            bottomMarker = bottomEdgeGO.transform;
        }


        verticalSpeed = Random.Range(-1.5f, 1.5f);
        StartCoroutine(FireWithDelay());

    }

    void Update()
    {
        transform.position += (Vector3.right * -2.0f + Vector3.up * verticalSpeed) * Time.deltaTime;
        if(transform.position.y > topMarker.position.y && verticalSpeed > 0)
        {
            verticalSpeed = -verticalSpeed;
        }

        if (transform.position.y < bottomMarker.position.y && verticalSpeed < 0)
        {
            verticalSpeed = -verticalSpeed;
        }
    }
   
    IEnumerator FireWithDelay()
    {
        while (true)
        {

            yield return new WaitForSeconds(1.0f);
            GameObject newShot = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
            if (transform.position.x < -9f)
            {
                Destroy(gameObject);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Add life variable to Red_SpaceShip - Ok
        //If redSpaceship is hit by laser once start first fire animation and reduce life variable
        //If redSpaceship is hit twice add additional fire animation and reduce life of variable.
        // if redSpaceship is hit the third time, destroy and apply explosion animation. 

        if (other.tag == "laser")
        {
          
            
                Destroy(other.gameObject);
                Destroy(this.gameObject);
          
        }

        if (other.tag == "largeLaser")
        {


        
                Destroy(other.gameObject);
                Destroy(this.gameObject);

          
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

}
