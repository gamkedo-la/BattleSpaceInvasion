using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMonsterBig_SpaceTree : MonoBehaviour
{
    private float speed = 5.0f;
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
        // Make treeSpaceShip spawn randomly from the right
        // Move treeSpaceShip after spawning to the left
        // Make treeSpaceShip dissapear when on the edge of the left side. 
    }
}
