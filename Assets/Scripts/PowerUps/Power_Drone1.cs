using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Drone1 : MonoBehaviour
{
    public GameObject drone1;
    public GameObject drone2;

    void Start()
    {
        drone1.SetActive(false);
        drone2.SetActive(false);
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
   
}
