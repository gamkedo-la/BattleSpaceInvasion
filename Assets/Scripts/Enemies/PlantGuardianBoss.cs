using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantGuardianBoss : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 5.0f;

    [SerializeField]
    private float health = 5;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(health == 0)
        {
            CameraShake.instance.Shake(100.0f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(10);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

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


    public void plantGuardianDamage()
    {
        health--;

        if(health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("DashEndSceneDialog");
        }
    }
}
