using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public float t;
     [SerializeField]
    private float speed;
    private Vector2 movement;
    //[SerializeField]
   // private float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Debug.Log("direction");
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }



    void FixedUpdate()
    {
        MoveBird(movement);
    }

    void MoveBird(Vector2 direction)
    {
       // transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        
        //if (transform.position.x == -20f)
        //{
        //    Debug.Log("Bird is at -20f");
        //    Vector3 a = transform.position;
        //    Vector3 b = target.position;
        //    transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed + 5);
        //}

    }
}
