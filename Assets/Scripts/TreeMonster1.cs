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
        // If treemonster1 hits the spaceShip - animate tree monster sticking on the ship.
        // Animate and transform tree monster into branches that sticks to the ship.
        // Reduce the speed of the spaceShip once treeMonster sticks on the spaceShip. 
        // Apply animation to treeMonster1 as if running on the ground and move left or right after touching ground
        // Respawn on top of the screen or trees when it collides with a tree on the Jungle Planet. 
    }
}
