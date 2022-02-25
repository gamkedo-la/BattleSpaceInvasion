using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public float degreesPerSec = 360f;
    private float speed = 5f;

    //Camera shake when this object gets destroyed - test
    private CameraShake shake;


    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float currentRotation = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRotation + rotAmount));
    }

    private void Move()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.tag == "laser")
        {
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other);
            Destroy(gameObject);
        }
        else if(other.tag == "Player")
        {
            shake.CamShakeAnimator();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            // TODO: Deal damage to player
        }
    }
}
