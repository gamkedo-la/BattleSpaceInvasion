
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject largeLaserPrefab;

    [SerializeField]
    private GameObject laserFireLeftPrefab;


    private bool isDroneFacingLeft = false;

    [SerializeField]
    private GameObject drone1;
    [SerializeField]
    private GameObject drone2;

    [SerializeField]
    private float speed;

    void Start()
    {
        //if drone1 is set active position y axis
        //if drone1 is set active position y axis
        //transform.position = new Vector3(-1.76f, 0.8f, 0);
        StartCoroutine(FireWithDelay());
    }


    void Update()
    {
        droneMovement();
    }



    IEnumerator FireWithDelay()
    {
        while (true)
        {
            fireLargeLaser();
            //fireLaserRobotLeft();
            yield return new WaitForSeconds(0.3f);
        }
        
        
    }

    //void changePosition()
    //{
        
    //    if (Player.robotMode = true)
    //    {
    //        transform.position = new Vector3(0, 0.20f, 0);
    //    }

    //}


    void fireLargeLaser()
    {
        Vector3 rotationVector = new Vector3(0, 0, 180);
        //GameObject LargeLaser  = (GameObject)Instantiate(largeLaserPrefab, transform.position + new Vector3(1.21f, 0, 0), Quaternion.Euler(rotationVector));
        if (transform.localScale.x < 0.0f && isDroneFacingLeft == true)
        {
            Vector3 rotationVectorLeft = new Vector3(0, 0, -180);
            GameObject LargeLaser = (GameObject)Instantiate(largeLaserPrefab, transform.position + new Vector3(-1.21f, 0, 0), Quaternion.Euler(rotationVectorLeft));
            //LargeLaser largeLaserScript = LargeLaser.GetComponent<LargeLaser>();
            //largeLaserScript.moveLeft = true;
           
        }
        else
        {
            GameObject LargeLaser = (GameObject)Instantiate(largeLaserPrefab, transform.position + new Vector3(1.21f, 0, 0), Quaternion.Euler(rotationVector));
        }
    }

    //void fireLaserRobotLeft()
    //{
    //    Vector3 rV = new Vector3(0, 0, -180);
    //    GameObject LaserLeft = (GameObject)Instantiate(laserFireLeftPrefab, transform.position + new Vector3(-1.21f, 0, 0), Quaternion.Euler(rV));
    //    LaserLeft laserDirectionLeft = LaserLeft.GetComponent<laserRobotLeft>();
    //}


    void droneMovement()
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
