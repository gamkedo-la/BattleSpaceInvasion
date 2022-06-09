using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalSceneCharacterDialog : MonoBehaviour
{
    private float speed = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(-17.0f, transform.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        CidMoveTowards();
        DrSamanthadMovement();
        //DrSamanthadMovement();
        //AlienPrincessdMovement();
    }

    private void CidMoveTowards()
    {
        //transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);

        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        //the speed, in units per second, we want to move towards the target
        Vector3 targetPosition = new Vector3(-6.61f, 0, 0);
        Vector3 currentPosition = this.transform.position;
        //first, check to see if we're close enough to the target
        if (Vector3.Distance(currentPosition,targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components
            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }

    
        //transform.position = new Vector3(-6.61f + (speed * Time.deltaTime), 0.8f, 0);
    }

    private void DrSamanthadMovement()
    {
        
        //the speed, in units per second, we want to move towards the target
        Vector3 targetPosition = new Vector3(5.97f, 0, 0);
        Vector3 currentPosition = this.transform.position;
        //first, check to see if we're close enough to the target
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components
            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }
        //transform.position = new Vector3(5.97f + (speed * Time.deltaTime), 0.8f, 0);
    }

    //private void AlienPrincessdMovement()
    //{

    //}
}
