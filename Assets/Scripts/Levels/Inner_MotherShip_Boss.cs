using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inner_MotherShip_Boss : MonoBehaviour
{
    //public Transform targetPosition;
    [SerializeField]
    private float speed;
    private bool stopMovement = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //position to setting position to target.
        //transform.position = targetPosition.position;

        //Lerp function that provides smooth transition to target.


        //Move toward 
        //Vector3 a = transform.position;
        //Vector3 b = targetPosition.position;
        //transform.position = Vector3.MoveTowards(a, b, speed);
        MoveMothership();
    }


    void MoveMothership()
    {
     
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);

        //transform = transform.position.x;


        //if(transform == -15 && stopMovement == true)
        //{
        //    stopMovement = true;
        //}
    }

}
