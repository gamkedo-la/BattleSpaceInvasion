using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject redSpaceShipPrefab;
    [SerializeField]
    private GameObject asteroid1Prefab;

    [SerializeField]
    private GameObject asteroid2Prefab;

    [SerializeField]
    private GameObject asteroid3Prefab;

    [SerializeField]
    private GameObject redEnemyContainer;


    private bool stopEnemySpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

   IEnumerator SpawnRoutine()
    {
        while (stopEnemySpawning == false)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(7f, -7f), 4, 0);
            Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.identity);

            Vector3 asteroid1ToSpawn = new Vector3(12, Random.Range(3f, -3f), 0);
            Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);

            Vector3 asteroid2ToSpawn = new Vector3(12, Random.Range(4f, -4f), 0);
            Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);

            Vector3 asteroid3ToSpawn = new Vector3(12, Random.Range(4f, -4f), 0);
            Instantiate(asteroid1Prefab, asteroid3ToSpawn, Quaternion.identity);

            Vector3 rotationVector = new Vector3(0, 0, 90);

            //New Asteroids
            
            GameObject newRedEnemy = Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.Euler(rotationVector));
            newRedEnemy.transform.parent = redEnemyContainer.transform;
            
            GameObject newAsteriod1 = Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);
            newAsteriod1.transform.parent = redEnemyContainer.transform;


            GameObject newAsteriod2 = Instantiate(asteroid2Prefab, asteroid2ToSpawn, Quaternion.identity);
            newAsteriod2.transform.parent = redEnemyContainer.transform;

            GameObject newAsteriod3 = Instantiate(asteroid3Prefab, asteroid3ToSpawn, Quaternion.identity);
            newAsteriod2.transform.parent = redEnemyContainer.transform;

            yield return new WaitForSeconds(3.0f);
        }
        
    }

    //spawn game objects 
    //create a coroutine of type IEnumerator -- Yield Events
    // while loop

    public void PlayerDies()
    {
        stopEnemySpawning = true;
    }

}
