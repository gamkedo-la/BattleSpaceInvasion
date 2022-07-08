using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunglePlanetBossWeapon : MonoBehaviour
{
    public GameObject shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireWithDelay());
    }

   
    IEnumerator FireWithDelay()
    {
        while (true)
        {

            yield return new WaitForSeconds(1.0f);
            GameObject newShot = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
           
        }
    }
}
