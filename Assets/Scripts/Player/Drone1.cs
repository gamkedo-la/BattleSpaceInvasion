
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1 : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject largeLaserPrefab;

    void Start()
    {
        StartCoroutine(FireWithDelay());
    }

    
    IEnumerator FireWithDelay()
    {
        while (true)
        {
            fireLargeLaser();
            yield return new WaitForSeconds(0.3f);
        }
        
        
    }


    void fireLargeLaser()
    {
        Vector3 rotationVector = new Vector3(0, 0, 180);
        Instantiate(largeLaserPrefab, transform.position + new Vector3(1.21f, 0, 0), Quaternion.Euler(rotationVector));

        

    }
}
