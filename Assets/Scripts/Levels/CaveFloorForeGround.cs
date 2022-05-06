using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveFloorForeGround : MonoBehaviour
{
    private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CaveForeGroundMovement();
    }

    void CaveForeGroundMovement()
    {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
    }
    
}
