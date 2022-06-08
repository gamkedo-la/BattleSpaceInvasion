using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Drone1 : MonoBehaviour
{
    public GameObject drone1;
    public GameObject drone2;
    private float speed = 5f;

    void Start()
    {
        drone1.SetActive(false);
        drone2.SetActive(false);
    }

    void Update()
    {
        PowerUpDroneMove();
    }

   void OnTriggerEnter2D(Collider2D collission) 
    {
        if(collission.gameObject.tag == "Player")
        {
            //Debug.Log("Drone power up bump");
            Player player = collission.transform.GetComponent<Player>();
           
            if ( player != null)
            {
                
                player.Drone1Active();
                drone1.SetActive(true);
                drone2.SetActive(true);
              

            }
            Destroy(gameObject);

        }
        
    }

    private void PowerUpDroneMove()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    }
   
}
