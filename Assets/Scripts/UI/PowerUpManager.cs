using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUpDronePrefab;
    //public GameObject powerUpDrone;
    
    private bool stopPowerUpSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PowerUpSpawnTime());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //spawn powerup every 10seconds

    IEnumerator PowerUpSpawnTime()
    {
        while (stopPowerUpSpawning == false)
        {
            Vector3 postToSpawn = new Vector3(4, Random.Range(7f, -7f), 0);
            Instantiate(powerUpDronePrefab, postToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
      
    }


}
