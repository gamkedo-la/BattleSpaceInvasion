using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetallicBird : MonoBehaviour
{
    public GameObject explosion;
    //public Transform target;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    public float t;
    [SerializeField]
    private float speed;

    private bool flyUp = false;
    private bool flyAtPlayer = false;
    private bool aimMode = false;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        float facingDY = Player.instance.transform.position.y - transform.position.y;
        float facingDX = Player.instance.transform.position.x - transform.position.x;
        float facingAng = Mathf.Atan2(facingDY, facingDX * 2) * Mathf.Rad2Deg;

        //Debug.Log(facingAng);
        if (aimMode)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, facingAng + 180f);
        }

        if (flyAtPlayer)
        {
            transform.Translate(transform.right * -1.0f * (speed * 3) * Time.deltaTime);
        }

        if (flyUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

  
    public void FlyUp()
    {
        Debug.Log("Fly Up");
        flyUp = true;
    }

    public void AimAtPlayer()
    {
        Debug.Log("Aim at player");
        aimMode = true;
        flyUp = false;
    }

    public void FlyAttack()
    {
        Debug.Log("Fly attack");
        flyAtPlayer = true;
        aimMode = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "laser")
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(1);
            Destroy(other);
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);

            Player player = other.transform.GetComponent<Player>();
            if (player != null) // perform a null check error handling. 
            {
                player.PlayerDamage();
            }

        }
        if (other.tag == "largeLaser")
        {



          
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.AddPoints(3);
            Destroy(other.gameObject);
            Destroy(this.gameObject);




        }

    }


}
