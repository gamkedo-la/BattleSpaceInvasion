using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 2.5f;
    private float speed_modifier = 1.0f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float nextFire = -1f;

    [SerializeField]
    private AudioClip laser1Sound;
    //[SerializeField]
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(0, 0, 0);

        if(audioSource == null)
        {
            Debug.LogError("AudioSource on JETSPACESHIP is NULL");
        }
        else
        {
            audioSource.clip = laser1Sound;
        }
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
        //Below are our test keys for jumping scenes for test cases. 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Reminder: Making this call requires using "using UnityEngine.SceneManagement;"
            SceneManager.LoadScene("GalaxyNebula");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("JungleLevel");
        }

    }

    void jetMovement()
    {
        float leftEdge = -9.8f;
        float rightEdge = 9.8f;
        float topEdge = 6f;
        float bottomEdge = -4f;
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * moveX * getTotalSpeed() * Time.deltaTime);
        transform.Translate(Vector3.up * moveY * getTotalSpeed() * Time.deltaTime);

        if ( transform.position.x >= rightEdge)
        {
            transform.position = new Vector3(rightEdge, transform.position.y, 0);
        } else if ( transform.position.x <= leftEdge)
        {
            transform.position = new Vector3(leftEdge, transform.position.y, 0);
        }
        if ( transform.position.y >= topEdge )
        {
            transform.position = new Vector3(transform.position.x, topEdge, 0);
        } else if(transform.position.y <= bottomEdge)
        {
            transform.position = new Vector3(transform.position.x, bottomEdge, 0);
        }
    }

    void fireLaser()
    {
        Vector3 rotationVector = new Vector3(0, 0, 180);
        Instantiate(_laserPrefab, transform.position + new Vector3(2.21f, 0, 0), Quaternion.Euler(rotationVector));

        audioSource.Play();
    }

    float getTotalSpeed()
    {
        return speed * speed_modifier;
    }

    void resetSpeedModifier()
    {
        speed_modifier = 1.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "power_up")
        {
            Power_Up power_up = other.gameObject.GetComponent<Power_Up_Display>().power_up;
            if (power_up != null && power_up.category == Power_Up.PowerUpCategory.Speed)
            {
                this.speed_modifier = power_up.multiplier;
            }

            Destroy(other.gameObject);
        }
    }
}

