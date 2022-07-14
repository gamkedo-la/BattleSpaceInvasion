using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMech : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float speed;
    int NextPositionIndex;
    Transform NextPos;

    [SerializeField]
    private GameObject tankMechLaserPrefab;
    [SerializeField]
    public GameObject laserSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0];
        StartCoroutine(AutoFire());
    }

    // Update is called once per frame
    void Update()
    {
        TankMechMovement();
        TankMechLaser();
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GameObject shotGO = GameObject.Instantiate(tankMechLaserPrefab) as GameObject;
            shotGO.transform.position = laserSpawnPoint.transform.position;
        }
    }


    void TankMechMovement()
    {
        if(transform.position == NextPos.position)
        {
            NextPositionIndex++;// where the next position in the array
            if (NextPositionIndex >= Positions.Length)
            {
                NextPositionIndex = 0;
            }
            NextPos = Positions[NextPositionIndex];

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, speed * Time.deltaTime);
        }
    }

    void TankMechLaser()
    {
       
    }

    
}
