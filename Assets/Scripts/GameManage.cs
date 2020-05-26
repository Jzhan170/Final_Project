using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static bool gameStarted;
    public static bool dialogFinished;
    public static bool dialog;

    public GameObject Title, UI, Dialog, DialogManager;
    public GameObject mentalBar;

    float fadeInSpeed = .75f;
    int finishedFadeIns;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        Title.SetActive(true);
        UI.SetActive(false);
        Dialog.SetActive(false);
        DialogManager.SetActive(false);
        dialog = false;
        dialogFinished = false;
        foreach(Transform t in UI.transform)
        {
            if (t.GetComponent<CanvasGroup>())
            {
                t.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0) && !dialog)
        {
            //gameStarted = true;
            //Title.SetActive(false);
            //UI.SetActive(true);
            dialog = true;
            Title.SetActive(false);
            Dialog.SetActive(true);
            DialogManager.SetActive(true);
        }
        if (dialogFinished)
        {
            //gameStarted = true;
            if (dialog)
            {
                dialog = false;
                Dialog.SetActive(false);
                DialogManager.SetActive(false);
                UI.SetActive(true);
            }
            
            if (!DataHolder.didTutorial)
            {
                Tutorial();
            }
            else
            {
                gameStarted = true;
            }
        }
        UI.GetComponent<CanvasGroup>().alpha = mentalBar.GetComponent<Image>().fillAmount;
    }

    void Tutorial()
    {
        Debug.Log("doing tutorial");

        //only display hunger bar
        FadeIn("foodBG");

        //highlight the fridge in some way

        //if player finished eating there, fade in other bars
        FadeIn("EntertainmentBG");
        FadeIn("RestBG");
        FadeIn("MentalBG");

        //if all four canvas groups' alpha = 1, say tutorial is finished
        if (finishedFadeIns == 4)
        {
            DataHolder.didTutorial = true;
        }    
    }
    void FadeIn(string name)
    {
        GameObject go = UI.transform.Find(name).gameObject;
        if (go.GetComponent<CanvasGroup>().alpha < 1)
        {
            go.GetComponent<CanvasGroup>().alpha += Time.deltaTime * fadeInSpeed;
        }
        else
        {
            go.GetComponent<CanvasGroup>().alpha = 1;
            finishedFadeIns += 1;
            return;
        }
    }
}
