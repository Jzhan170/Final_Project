using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    //Allows for the object with the Camera Shake script to be added to be able to access it here.
    public CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        //Once the player character enters the trigger object collider, then
        //the camera shaking is initiated.
        if (other.gameObject.tag == "ShakeTrigger")
        {
            //The two variables here allow for editing of the magnitude as well as the duration of the shake
            cameraShake.ScreenShake(.9f, 3.8f);
        }
    }
}
