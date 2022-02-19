using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up_Display : MonoBehaviour
{
    public Power_Up power_up;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();
        if (sprite_renderer && this.power_up)
        {
            sprite_renderer.sprite = this.power_up.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
