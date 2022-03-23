using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jungle_Script : MonoBehaviour
{
    [SerializeField]
    private Vector2 scrollSpeed;

    private float timer = 6.1f;

    private Material materialToScroll;
    // Start is called before the first frame update
    void Start()
    {
        materialToScroll = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        materialToScroll.mainTextureOffset += scrollSpeed * Time.deltaTime;

        timer -= Time.deltaTime;
        
        if (timer <= 0 ) // set timer and collider for entrance to ruins scene object.
        {
            SceneManager.LoadScene("CaveLevel");
        }
        
    }
}
