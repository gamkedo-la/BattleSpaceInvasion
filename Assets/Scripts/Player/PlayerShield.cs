using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update

    private bool shieldActive = false;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        transform.position = Player.currentPos; 
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.currentPos; 
        shieldActive = Player.shieldActive;
        Color newColor = spriteRenderer.color;
        newColor.r += Time.deltaTime*0.5f;
        newColor.g += Time.deltaTime*0.75f;
        newColor.b += Time.deltaTime*1.0f;
        // ideally this would be done in a shader
        if (newColor.r > 1.0f) {
            newColor.r = 0.0f;
        }
        if (newColor.g > 1.0f) {
            newColor.g = 0.0f;
        }
        if (newColor.b > 1.0f) {
            newColor.b = 0.0f;
        }
        spriteRenderer.color = newColor;
        if (shieldActive) 
        {
            gameObject.layer = 0; // default layer
            transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * 360.0f);
        } 
        else
        {
            gameObject.layer = 3; // invisible debug layer (hardcoded for now)
        } 
        
    }
}
