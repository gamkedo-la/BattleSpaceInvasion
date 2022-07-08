using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunglePlanetBossWeapon : MonoBehaviour
{
    public GameObject shotPrefab;
    private static Transform topMarker;
    private static Transform bottomMarker;
    private float verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (topMarker == null)
        {
            GameObject topEdgeGO = GameObject.Find("ScreenTop");
            topMarker = topEdgeGO.transform;

            GameObject bottomEdgeGO = GameObject.Find("ScreenBottom");
            bottomMarker = bottomEdgeGO.transform;
        }


        verticalSpeed = Random.Range(-1.5f, 1.5f);
        StartCoroutine(FireWithDelay());

    }

    void Update()
    {
        transform.position += (Vector3.right * -2.0f + Vector3.up * verticalSpeed) * Time.deltaTime;
        if(transform.position.y > topMarker.position.y && verticalSpeed > 0)
        {
            verticalSpeed = -verticalSpeed;
        }

        if (transform.position.y < bottomMarker.position.y && verticalSpeed < 0)
        {
            verticalSpeed = -verticalSpeed;
        }
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
