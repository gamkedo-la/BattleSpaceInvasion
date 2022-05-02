using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Story : MonoBehaviour
{
    private float speed = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(31f,2.6f,0);
    }

    // Update is called once per frame
    void Update()
    {
        CaptainCidMovement();
    }


    void CaptainCidMovement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
