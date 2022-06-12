using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeLaser : MonoBehaviour
{
    [SerializeField]
    private int laserSpeed = 1000;
    public bool moveLeft = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * laserSpeed * (moveLeft ? -1.0f : 1.0f));

        if (transform.position.x > 10f || transform.position.x < -15f)
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
                Debug.Log("LargeLaser Hits RED SHIP");
            }
            Destroy(this.gameObject);
        }


        if (other.tag == "ufo1Tag")
        {
            // TODO: Deal damage to ufo1

            Ufo1 ufo1 = other.transform.GetComponent<Ufo1>();

            if (ufo1 != null) // perform a null check error handling. 
            {
                ufo1.ufo1Damage();
                Debug.Log("Laser Hits UFO1");
            }
            Destroy(this.gameObject);
        }

      




    }
}
