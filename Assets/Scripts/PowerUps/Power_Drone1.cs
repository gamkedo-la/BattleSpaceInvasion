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

   void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Drone power up bump");
            drone1.SetActive(true);
            drone2.SetActive(true);
            Destroy(gameObject);
        }
        
    }
   
}
