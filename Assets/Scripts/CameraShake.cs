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
    // hot to use animation.Stop()  to stop shake once object is destroyed. - WIP

}
