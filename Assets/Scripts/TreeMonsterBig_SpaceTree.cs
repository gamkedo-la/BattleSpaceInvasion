using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMonsterBig_SpaceTree : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(7, -2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        treeSpaceShip_Movement();
    }


    void treeSpaceShip_Movement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
