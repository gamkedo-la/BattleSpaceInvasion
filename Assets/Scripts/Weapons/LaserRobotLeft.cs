using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRobotLeft : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isRobotFacingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRobotFacingLeft == true)
        {
            spriteRenderer.enabled = true;
        }
    }


    //set this object to appear once droneIsFacingLeft
    //disable the LargeLaser spriterenderer when droneIsf


}
