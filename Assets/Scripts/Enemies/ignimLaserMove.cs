using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignimLaserMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Laser created");
        Destroy(gameObject, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
