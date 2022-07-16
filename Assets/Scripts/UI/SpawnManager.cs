using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject redSpaceShipPrefab;

    [SerializeField]
    private GameObject redSpaceShipLeftPrefab;

    [SerializeField]
    private GameObject asteroid1Prefab;

    [SerializeField]
    private GameObject asteroid2Prefab;

    [SerializeField]
    private GameObject asteroid3Prefab;

    [SerializeField]
    private GameObject botTentaclesPrefab;

    [SerializeField]
    private GameObject projectileEnemyPrefab;

    [SerializeField]
    private GameObject redEnemyContainer;

    [SerializeField]
    private float spawnInterval = 3.0f;


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
            Vector3 postToSpawn = new Vector3(Random.Range(2.6f, -7f), 4, 0);
            Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.identity);


            Vector3 redEnemyLeft = new Vector3(Random.Range(2.6f, -7f), 4, 0);
            Instantiate(redSpaceShipLeftPrefab, redEnemyLeft, Quaternion.identity);

            Vector3 asteroid1ToSpawn = new Vector3(12, Random.Range(2.6f, -3f), 0);
            Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);

            Vector3 asteroid2ToSpawn = new Vector3(12, Random.Range(2.6f, -4f), 0);
            Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);

            Vector3 asteroid3ToSpawn = new Vector3(12, Random.Range(2.6f, -4f), 0);
            Instantiate(asteroid1Prefab, asteroid3ToSpawn, Quaternion.identity);

            Vector3 botTentaclesToSpawn = new Vector3(12, Random.Range(Player.instance.topMarker.position.y, Player.instance.bottomMarker.position.y), 0);
            Instantiate(botTentaclesPrefab, botTentaclesToSpawn, Quaternion.identity);

            Vector3 rotationVector = new Vector3(0, 0, 90);

            //New Asteroids
            
            GameObject newRedEnemy = Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.Euler(rotationVector));
            newRedEnemy.transform.parent = redEnemyContainer.transform;

            GameObject newRedEnemyLeft = Instantiate(redSpaceShipLeftPrefab, redEnemyLeft, Quaternion.Euler(rotationVector));
            newRedEnemyLeft.transform.parent = redEnemyContainer.transform;

            GameObject newAsteriod1 = Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);
            newAsteriod1.transform.parent = redEnemyContainer.transform;


            GameObject newAsteriod2 = Instantiate(asteroid2Prefab, asteroid2ToSpawn, Quaternion.identity);
            newAsteriod2.transform.parent = redEnemyContainer.transform;

            GameObject newAsteriod3 = Instantiate(asteroid3Prefab, asteroid3ToSpawn, Quaternion.identity);
            newAsteriod2.transform.parent = redEnemyContainer.transform;

            GameObject newBotTentacles = Instantiate(botTentaclesPrefab, botTentaclesToSpawn, Quaternion.identity);
            newBotTentacles.transform.parent = redEnemyContainer.transform;

            Vector3 projectileEnemyToSpawn = new Vector3(8, Random.Range(4.6f, -4f), 0);
            Instantiate(projectileEnemyPrefab, projectileEnemyToSpawn, Quaternion.identity);

            GameObject newProjectileEnemy = Instantiate(projectileEnemyPrefab, projectileEnemyToSpawn, Quaternion.identity);
            newProjectileEnemy.transform.parent = redEnemyContainer.transform;

            yield return new WaitForSeconds(spawnInterval);

            //new RedShipEnemyLeft


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
