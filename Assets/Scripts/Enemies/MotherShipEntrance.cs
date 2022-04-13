using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipEntrance : MonoBehaviour
{
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
    }


    private void Move()
    {
        if (ScoreManager.instance.GetScore() >= minimumScoreHundredNeeded)
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
        }

        
        // Stop moving when entrance is shown on screen. Still looking for examples. 
        // Try using IEnumerator - while yield return. 

        //if (transform.position == 22f)
        //{
        //    this.Stop;
        //}
    }
}
