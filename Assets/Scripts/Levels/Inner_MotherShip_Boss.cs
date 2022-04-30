using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inner_MotherShip_Boss : MonoBehaviour
{

    public GameObject motherShip;

    private AudioSource audioSource;

    [SerializeField]
    Transform[] Positions;

    private int NextPositionIndex;
    Transform NextPosition;
    //public Transform targetPosition;
    [SerializeField]
    private float speed;
    private bool stopMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        NextPosition = Positions[0];
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
     
        //transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
        //transform = transform.position.x;
        //if(transform.position.x <= -15f && stopMovement == true)
        //{
        //    Debug.Log("X position is at -15");
        //    stopMovement = true;
        //    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //}

        if(transform.position == NextPosition.position)
        {
            NextPositionIndex++;
            if (NextPositionIndex >= Positions.Length)
            {
                NextPositionIndex = 0;
            }
            NextPosition = Positions[NextPositionIndex];

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,NextPosition.position,speed * Time.deltaTime);
        }
    }

}
