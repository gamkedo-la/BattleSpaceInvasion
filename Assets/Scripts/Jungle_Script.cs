using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jungle_Script : MonoBehaviour
{
    [SerializeField]
    private Vector2 scrollSpeed;

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
    }
}
