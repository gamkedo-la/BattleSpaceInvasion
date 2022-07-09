using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnimbriteHandCanon : MonoBehaviour
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


        if (other.tag == "Player")
        {
            CameraShake.instance.Shake(100.0f);
            //Instantiate(explosion, transform.position, Quaternion.identity);
            // TODO: Deal damage to player

            Player player = other.transform.GetComponent<Player>();
            if (player != null) // perform a null check error handling. 
            {
                player.PlayerDamage();
            }
            Destroy(this.gameObject);

        }


    }

}
