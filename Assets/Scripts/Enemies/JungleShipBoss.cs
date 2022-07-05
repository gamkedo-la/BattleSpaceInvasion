using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JungleShipBoss : MonoBehaviour
{
    public GameObject explosion;
    public GameObject fireBallPrefab;
    private float speed = 5.0f;
    //private float health = 3f;


    private Vector3 scaleChange;
    [SerializeField]
    private int jungleShipBossLives = 10;

    [SerializeField] Transform[] Positions;
    Transform NextPosition;

    [SerializeField] float ObjectSpeed;

    int NextPositionIndex;

    // Start is called before the first frame update
    void Start()
    {

        NextPosition = Positions[0];
        StartCoroutine(fireBlastRepeat());

        //transform.position = new Vector3(13, 4, 0);
        //scaleChange = new Vector3(0.4f, 0.4f, 1);

    }

    IEnumerator fireBlastRepeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
            GameObject blastEffect = GameObject.Instantiate(fireBallPrefab, transform.position - Vector3.right * 6.0f, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        MoveJungleShipBoss();
        //transform.localScale = scaleChange; // used localScale property to scale object. 
        ////redSpaceshipMovement();
        //if (transform.position.x < -9f)
        //{
        //    float random = Random.Range(-3f, 3f);
        //    transform.position = new Vector3(8, random, 0);
        //}
    }



    void MoveJungleShipBoss()
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
            transform.position = Vector3.MoveTowards(transform.position, NextPosition.position, ObjectSpeed * Time.deltaTime);
        }
    }
    //void redSpaceshipMovement()
    //{

    //    transform.Translate(Vector3.up * speed * Time.deltaTime);

    //}


    void OnTriggerEnter2D(Collider2D other)
    {
        //Add life variable to Red_SpaceShip - Ok
        //If redSpaceship is hit by laser once start first fire animation and reduce life variable
        //If redSpaceship is hit twice add additional fire animation and reduce life of variable.
        // if redSpaceship is hit the third time, destroy and apply explosion animation. 

        if (other.tag == "laser")
        {


            if (jungleShipBossLives == 0)
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


            if (jungleShipBossLives == 0)
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
            Destroy(this.gameObject);

        }

    }

    public void jungleShipBossDamage()
    {
        jungleShipBossLives--;

        if (jungleShipBossLives <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SceneManager.LoadScene("CaveSceneEntrance");
        }
    }
}
