using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunglePlanetBossWeapon : MonoBehaviour
{
    public GameObject shotPrefab;

    private float verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        verticalSpeed = Random.Range(-1.5f, 1.5f);
        StartCoroutine(FireWithDelay());

    }

    void Update()
    {
        transform.position += (Vector3.right * -2.0f + Vector3.up * verticalSpeed) * Time.deltaTime;
    }
   
    IEnumerator FireWithDelay()
    {
        while (true)
        {

            yield return new WaitForSeconds(1.0f);
            GameObject newShot = GameObject.Instantiate(shotPrefab, transform.position, Quaternion.identity);
            if (transform.position.x < -9f)
            {
                Destroy(gameObject);
            }
        }
    }
}
