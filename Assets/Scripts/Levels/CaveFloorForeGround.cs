using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveFloorForeGround : MonoBehaviour
{
    private float CaveForeGroundSpeed = 1.0f;
    private float CaveBottomSpikeSpeed = 0.5f;


    [SerializeField]
    Transform[] Positions;

    private int NextPositionIndex;
    Transform NextPosition;


    // Start is called before the first frame update
    void Start()
    {
        NextPosition = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        CaveForeGroundMovement();
        //CaveBottomSpike();
    }

    void CaveForeGroundMovement()
    {
        //transform.position = new Vector3(transform.position.x - (CaveForeGroundSpeed * Time.deltaTime), transform.position.y, 0);
        if(transform.position == NextPosition.position)
        {
            NextPositionIndex++;
            if (NextPositionIndex >= Positions.Length)
            {
                NextPositionIndex = 0;
            }
            NextPosition = Positions[NextPositionIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPosition.position, CaveForeGroundSpeed * Time.deltaTime);
        }
    }
    

    //void CaveBottomSpike()
    //{
    //    transform.position = new Vector3(transform.position.x - (CaveBottomSpikeSpeed * Time.deltaTime), transform.position.y, 0);
    //}
}
