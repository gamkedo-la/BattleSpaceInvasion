using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ignimbrite1 : MonoBehaviour
{
    public GameObject ignimbriteLaserPrefab;
    public Transform ignimLaserFirePosition;
    public GameObject handLaserPrefab;
    public Transform handLaserFirePosition;

    public GameObject explosion;
    private float speed = 5.0f;

    private Vector3 scaleChange;
    [SerializeField]
    private float health = 10;

    private float totalHealth;


    [SerializeField]
    Transform[] Positions;

    private int NextPositionIndex;
    Transform NextPosition;

    // Start is called before the first frame update
    void Start()
    {

        //transform.position = new Vector3(13, 4, 0);
        //scaleChange = new Vector3(0.4f, 0.4f, 1);
        totalHealth = health;
        NextPosition = Positions[0];
        StartCoroutine(FireBigLaser());
    }

    IEnumerator FireBigLaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            GameObject laserGO = GameObject.Instantiate(ignimbriteLaserPrefab);
            laserGO.transform.position = ignimLaserFirePosition.position;

        }
    }

    

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = scaleChange; // used localScale property to scale object. 
        ////redSpaceshipMovement();
        //if (transform.position.x < -9f)
        //{
        //    float random = Random.Range(-3f, 3f);
        //    transform.position = new Vector3(8, random, 0);
        //}
        IgnimbriteMovement();
    }

    //void redSpaceshipMovement()
    //{

    //    transform.Translate(Vector3.up * speed * Time.deltaTime);

    //}

    public void fireHandCannon()
    {
        Debug.Log("Hand up");
       
        GameObject laserGO = GameObject.Instantiate(handLaserPrefab);
        laserGO.transform.position = handLaserFirePosition.position;

    }

void IgnimbriteMovement()
    {
        if (transform.position == NextPosition.position)
        {
            NextPositionIndex++;
            if (NextPositionIndex >= Positions.Length)
            {
                NextPositionIndex = 0;
            }
            NextPosition = Positions[NextPositionIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPosition.position, speed * Time.deltaTime);
        }
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        //Add life variable to Red_SpaceShip - Ok
        //If redSpaceship is hit by laser once start first fire animation and reduce life variable
        //If redSpaceship is hit twice add additional fire animation and reduce life of variable.
        // if redSpaceship is hit the third time, destroy and apply explosion animation. 

        if (other.tag == "laser")
        {


            if (health == 0)
            {
                CameraShake.instance.Shake(100.0f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.instance.AddPoints(3);
                Destroy(other.gameObject);
                Destroy(this.gameObject);

            }
            //Destroy(this.gameObject);

        }

        if (other.tag == "largeLaser")
        {


            if (health == 0)
            {
                CameraShake.instance.Shake(100.0f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.instance.AddPoints(3);
                Destroy(other.gameObject);
                Destroy(this.gameObject);

            }
            //Destroy(this.gameObject);

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
            //Destroy(this.gameObject);

        }

    }

    public float GetCurrentHealth() {
        return health;
    }

    public float GetTotalHealth() {
        return totalHealth;
    }

    public void ignimbrite1Damage()
    {
        health--;

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("ShipDashBoardDialog");
        }
    }
}
