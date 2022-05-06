using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveFloorForeGround : MonoBehaviour
{
    private float CaveForeGroundSpeed = 1.0f;
    private float CaveBottomSpikeSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CaveForeGroundMovement();
        //CaveBottomSpike();
    }

    void CaveForeGroundMovement()
    {
        transform.position = new Vector3(transform.position.x - (CaveForeGroundSpeed * Time.deltaTime), transform.position.y, 0);
    }
    

    //void CaveBottomSpike()
    //{
    //    transform.position = new Vector3(transform.position.x - (CaveBottomSpikeSpeed * Time.deltaTime), transform.position.y, 0);
    //}
}
