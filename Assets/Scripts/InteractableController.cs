using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    [Header("Status Changes to Player once Entered")]
    public float hunger;
    public float stamina;
    public float health;
    public float mental;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManage.gameStarted)
        {
            NewPlayerController.Food += hunger;
            NewPlayerController.SMN += stamina;
            NewPlayerController.Health += health;
            MentalBarController.Mental += mental;
        }
    }
}
