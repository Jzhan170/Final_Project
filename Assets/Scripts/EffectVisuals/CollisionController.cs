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
    public string BedInteract = "BedInteract";
    public string GymInteract = "WorkoutInteract";
    public string BookInteract1 = "BookInteract1";
    public string BookInteract2 = "BookInteract2";
    public string Shatter1 = "BottleShatter";
    public string Shatter2 = "RGlassShatter";
    public string Shatter3 = "GlasshShatter";




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
            cameraShake.ScreenShake(1.6f, 6f);
        }

        if (other.gameObject.tag == "FoodInteract")
        {
            audioManager.PlaySound(FridgeInteract);
        }

        if (other.gameObject.tag == "PCInteract")
        {
            audioManager.PlaySound(GameController);
        }

        if (other.gameObject.tag == "BedInteract")
        {
            audioManager.PlaySound(BedInteract);
        }

        if (other.gameObject.tag == "GymInteract")
        {
            audioManager.PlaySound(GymInteract);
        }

        if (other.gameObject.tag == "BookInteract")
        {
            audioManager.PlaySound(BookInteract1);
            audioManager.PlaySound(BookInteract2);
        }


        if (other.gameObject.tag == "DarkInteractable")
        {
            audioManager.PlaySound(Shatter1);
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FoodInteract")
        {
            audioManager.StopSound(FridgeInteract);
        }

        if (other.gameObject.tag == "PCInteract")
        {
            audioManager.StopSound(GameController);
        }

        if (other.gameObject.tag == "BedInteract")
        {
            audioManager.StopSound(BedInteract);
        }

        if (other.gameObject.tag == "GymInteract")
        {
            audioManager.StopSound(GymInteract);
        }

        if (other.gameObject.tag == "BookInteract")
        {
            audioManager.StopSound(BookInteract1);
            audioManager.StopSound(BookInteract2);
        }

        if (other.gameObject.tag == "DarkInteractable")
        {
            audioManager.StopSound(Shatter1);
        }
    }
}
