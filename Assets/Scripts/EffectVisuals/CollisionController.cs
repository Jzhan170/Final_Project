using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    //Allows for the object with the Camera Shake script to be added to be able to access it here.
    public CameraShake cameraShake;

    //Sounds
    private AudioManager audioManager;
    public string FridgeInteract = "FridgeInteract";
    public string GameController = "GameController";



    void Start()
    {
        //caching. Just in case AudioManager happens to be missing from the scene
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("FREAK OUT! No AudioManager found in the scene.");
        }


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

        if (other.gameObject.tag == "food")
        {
            audioManager.PlaySound(FridgeInteract);
        }
        if (other.gameObject.tag == "action")
        {
            audioManager.PlaySound(GameController);
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            audioManager.StopSound(FridgeInteract);
        }

        if (other.gameObject.tag == "action")
        {
            audioManager.StopSound(GameController);
        }
    }
}
