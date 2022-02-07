using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 2.5f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float nextFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        jetMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + _fireRate;
           
            fireLaser();
        }
            
    }

    void jetMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * speed * Time.deltaTime);
        
        if ( transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        } else if(transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
            
        
    }

    void fireLaser()
    {
        Vector3 rotationVector = new Vector3(0, 0, 180);
        Instantiate(_laserPrefab, transform.position + new Vector3(2.21f, 0, 0), Quaternion.Euler(rotationVector));
    }
}

