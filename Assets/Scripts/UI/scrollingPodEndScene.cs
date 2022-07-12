using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollingPodEndScene : MonoBehaviour
{
    [SerializeField] private RawImage bgImg;
    [SerializeField] private float x, y;

    // Update is called once per frame
    void Update()
    {
        bgImg.uvRect = new Rect(bgImg.uvRect.position + new Vector2(-x, y) * Time.deltaTime, bgImg.uvRect.size);
    }
}
