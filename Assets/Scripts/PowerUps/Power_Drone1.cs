using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Drone1 : MonoBehaviour
{
    public GameObject drone;

    void Start()
    {
        drone.SetActive(false);
    }

   void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Drone power up bump");
            drone.SetActive(true);
            Destroy(gameObject);
        }
        
    }
   
}
