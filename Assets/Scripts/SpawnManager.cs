using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject redSpaceShipPrefab;

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
        Vector3 postToSpawn = new Vector3(Random.Range(7f, -7f), 4, 0);
        Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.identity);
        Vector3 rotationVector = new Vector3(0, 0, 90);
        Instantiate(redSpaceShipPrefab, postToSpawn, Quaternion.Euler(rotationVector));

        yield return new WaitForSeconds(5.0f);
    }

    //spawn game objects 
    //create a coroutine of type IEnumerator -- Yield Events
    // while loop

}
