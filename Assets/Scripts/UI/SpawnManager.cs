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
    private GameObject redEnemyContainer;


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
        while (true)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(7f, -7f), 4, 0);
            Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.identity);

            Vector3 asteroid1ToSpawn = new Vector3(Random.Range(7f, -7f), 4, 0);
            Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);

            Vector3 rotationVector = new Vector3(0, 0, 90);
            
            GameObject newRedEnemy = Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.Euler(rotationVector));
            newRedEnemy.transform.parent = redEnemyContainer.transform;
            
            GameObject newAsteriod1 = Instantiate(asteroid1Prefab, asteroid1ToSpawn, Quaternion.identity);
            newAsteriod1.transform.parent = redEnemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
        
    }

    //spawn game objects 
    //create a coroutine of type IEnumerator -- Yield Events
    // while loop

}
