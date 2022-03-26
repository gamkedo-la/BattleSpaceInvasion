
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject largeLaserPrefab;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        fireLargeLaser();
        // gameObject.GetComponent<spriteRenderer>().enabled = true; //Activate this when we have collected a power up.
    }


    void fireLargeLaser()
    {
        Vector3 rotationVector = new Vector3(0, 0, 180);
        Instantiate(largeLaserPrefab, transform.position + new Vector3(2.21f, 0, 0), Quaternion.Euler(rotationVector));

        

    }
}
