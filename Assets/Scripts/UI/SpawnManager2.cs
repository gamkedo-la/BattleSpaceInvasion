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
    private GameObject redEnemyContainer;

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



            yield return new WaitForSeconds(3.0f);

            //new RedShipEnemyLeft


        }

    }

    public void PlayerDies()
    {
        stopEnemySpawning = true;
    }

}