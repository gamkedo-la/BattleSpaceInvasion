using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBird();
        
    }

    void MoveBird()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    }
}
