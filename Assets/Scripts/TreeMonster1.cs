using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMonster1 : MonoBehaviour
{
    private float speed = 5.0f;
    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 4, 0);
        scaleChange = new Vector3(0.2f, 0.2f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scaleChange; // used localScale property to scale object. 
        treeMonster1_Movement();
    }


    void treeMonster1_Movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
