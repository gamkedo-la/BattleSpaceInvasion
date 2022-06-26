using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignimLaserMove : MonoBehaviour
{
    public GameObject explosion;
    private float moveSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            CameraShake.instance.Shake(100.0f);
            Instantiate(explosion, transform.position, Quaternion.identity);
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
