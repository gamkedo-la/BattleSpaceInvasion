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


    [SerializeField]
    Transform[] Positions;

    private int NextPositionIndex;
    Transform NextPosition;


    public GameObject weaponPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireWithDelay());
        NextPosition = Positions[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        planetGuardianMovement();
    }

    void planetGuardianMovement()
    {
        if(transform.position == NextPosition.position)
        {
            NextPositionIndex++;
            if(NextPositionIndex >= Positions.Length)
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


    IEnumerator FireWithDelay()
    {
        while (true)
        {

            yield return new WaitForSeconds(5.0f);
            GameObject newShot = GameObject.Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        }
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
            //Destroy(this.gameObject);

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
