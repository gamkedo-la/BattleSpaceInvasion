using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Drone1 : MonoBehaviour
{
   
    
    private float speed = 2f;
    public float degreesPerSec = 300f;
    private float rotationSpeed = 0.5f;

   

    void Start()
    {
       
    }

    void Update()
    {
        PowerUpDroneMove();
        Rotate();
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
             
            }
            Destroy(gameObject);

        }
        
    }

    private void PowerUpDroneMove()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    }

    private void Rotate()
    {
        float rotAmount = degreesPerSec * rotationSpeed  * Time.deltaTime;
        float currentRotation = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation + rotAmount));
    }




}
