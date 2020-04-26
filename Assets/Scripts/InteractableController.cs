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
    public float actionTime;

    bool actionStart;

    // Start is called before the first frame update
    void Start()
    {
        actionStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (actionStart)
        {
            NewPlayerController.actTime += Time.deltaTime;
            NewPlayerController.coolDownFill = NewPlayerController.actTime / actionTime;
            NewPlayerController.actionDone = false;
        }
        if (NewPlayerController.actTime >= actionTime && actionStart)
        {
            NewPlayerController.actTime = 0;
            actionStart = false;
            NewPlayerController.actionDone = true;
            NewPlayerController.Food += hunger;
            NewPlayerController.SMN += stamina;
            NewPlayerController.Health += health;
            MentalBarController.Mental += mental;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManage.gameStarted)
        {
            NewPlayerController.actTime = 0;
            actionStart = true;
            NewPlayerController.actionDone = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && GameManage.gameStarted)
        {
            actionStart = false;
            NewPlayerController.actTime = 0;
            NewPlayerController.actionDone = false;
        }
    }
}
