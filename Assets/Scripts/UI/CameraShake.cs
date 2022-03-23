using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private Vector3 cameraStart;
    private float shakeEnergy = 0.0f;
    private float shakeDecay = 0.7f;
    private float dampenEffect = 0.3f;
    void Start()
    {
        instance = this;
        cameraStart = Camera.main.transform.position;
    }

    void FixedUpdate()
    {
        Camera.main.transform.position = cameraStart + Random.insideUnitSphere * shakeEnergy * dampenEffect;
        shakeEnergy *= shakeDecay;
    }

    public void Shake(float power)
    {
        if (power > shakeEnergy)
        {
            shakeEnergy = power;
        }
    }
    
    //need to figure out how to make cameraShake follow spaceship 
    // hot to use animation.Stop()  to stop shake once object is destroyed. - WIP

}
