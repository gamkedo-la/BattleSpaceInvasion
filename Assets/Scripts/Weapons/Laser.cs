using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private int laserSpeed = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * laserSpeed);

        if (transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
    }

    //Boost speed of laser when powerUp is collected. 

    //damage redSpaceShip 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "redShipEnemy")
        {
            // TODO: Deal damage to redSpaceShip

            Red_SpaceShip_Enemy1 redSpaceShip = other.transform.GetComponent<Red_SpaceShip_Enemy1>();
            if (redSpaceShip != null) // perform a null check error handling. 
            {
                redSpaceShip.redSpaceShipDamage();
            }
            Destroy(this.gameObject);
        }

    }

}