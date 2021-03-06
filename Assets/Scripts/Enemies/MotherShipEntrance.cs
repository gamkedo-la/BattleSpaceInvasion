using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MotherShipEntrance : MonoBehaviour
{
    public Transform playerReference;
    public Transform doorReference;
    public int minimumScoreHundredNeeded = 20;
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.O))
        {
            ScoreManager.instance.AddPoints(minimumScoreHundredNeeded);
            Debug.Log("Test Starting Boss Movement");
        }
    }


    private void Move()
    {
        if (ScoreManager.instance.GetScore() >= minimumScoreHundredNeeded)
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
            if (playerReference.position.x > doorReference.position.x)
            {
                SceneManager.LoadScene("MotherShip");
                Debug.Log("Load next scene");
            }
        }

        
        // Stop moving when entrance is shown on screen. Still looking for examples. 
        // Try using IEnumerator - while yield return. 

        //if (transform.position == 22f)
        //{
        //    this.Stop;
        //}
    }
}
