using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Story : MonoBehaviour
{
    private float speed = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
     //   transform.position = new Vector3(31f,2.6f,0);
    }

    // Update is called once per frame
    void Update()
    {
        CaptainCidMovement();
        DrSamanthaMovement();
        AlienPrincesMovement();
    }


    void CaptainCidMovement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    void DrSamanthaMovement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void AlienPrincesMovement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
