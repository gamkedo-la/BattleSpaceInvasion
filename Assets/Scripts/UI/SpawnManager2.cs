using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    [SerializeField]
    private GameObject redSpaceShipPrefab;

    [SerializeField]
    private GameObject redSpaceShipLeftPrefab;

    [SerializeField]
    private GameObject botTentaclesPrefab;

    [SerializeField]
    private GameObject projectileEnemyPrefab;

    [SerializeField]
    private GameObject metallicBirdEnemyPrefab;

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


    IEnumerator SpawnRoutine()
    {
        while (stopEnemySpawning == false)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(7f, -7f), 4, 0);
            Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.identity);


            Vector3 redEnemyLeft = new Vector3(Random.Range(7f, -7f), 4, 0);
            Instantiate(redSpaceShipLeftPrefab, redEnemyLeft, Quaternion.identity);
            Vector3 rotationVector = new Vector3(0, 0, 90);

            GameObject newRedEnemy = Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.Euler(rotationVector));
            newRedEnemy.transform.parent = redEnemyContainer.transform;

            GameObject newRedEnemyLeft = Instantiate(redSpaceShipLeftPrefab, redEnemyLeft, Quaternion.Euler(rotationVector));
            newRedEnemyLeft.transform.parent = redEnemyContainer.transform;

            Vector3 botTentaclesToSpawn = new Vector3(12, Random.Range(2.6f, -4f), 0);
            Instantiate(botTentaclesPrefab, botTentaclesToSpawn, Quaternion.identity);

            GameObject newBotTentacles = Instantiate(botTentaclesPrefab, botTentaclesToSpawn, Quaternion.identity);
            newBotTentacles.transform.parent = redEnemyContainer.transform;

            Vector3 projectileEnemyToSpawn = new Vector3(12, Random.Range(2.6f, -4f), 0);
            Instantiate(projectileEnemyPrefab, projectileEnemyToSpawn, Quaternion.identity);

            GameObject newProjectileEnemy = Instantiate(projectileEnemyPrefab, projectileEnemyToSpawn, Quaternion.identity);
            newProjectileEnemy.transform.parent = redEnemyContainer.transform;

            Vector3 metallicBirdEnemyToSpawn = new Vector3(12, Random.Range(4.51f, -2.5f), 0);
            Instantiate(metallicBirdEnemyPrefab, metallicBirdEnemyToSpawn, Quaternion.identity);

            GameObject newMetallicBirdEnemy = Instantiate(metallicBirdEnemyPrefab, metallicBirdEnemyToSpawn, Quaternion.identity);
            newMetallicBirdEnemy.transform.parent = redEnemyContainer.transform;

            yield return new WaitForSeconds(spawnInterval);

            //new RedShipEnemyLeft


        }

    }

    public void PlayerDies()
    {
        stopEnemySpawning = true;
    }

}
