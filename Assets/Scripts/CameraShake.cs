using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator cameraAnimator;

    public void CamShakeAnimator()
    {
        cameraAnimator.SetTrigger("shake");
    }

    //need to figure out how to make cameraShake follow spaceship 
    //stop shake once object is destroyed. 
}
