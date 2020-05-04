using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static bool gameStarted;
    public static bool dialogFinished;
    public GameObject Title, UI, Dialog;
    public GameObject mentalBar;
    public static bool dialog;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        Title.SetActive(true);
        UI.SetActive(false);
        Dialog.SetActive(false);
        dialog = false;
        dialogFinished = false;
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
        }
        if (dialog && dialogFinished)
        {
            gameStarted = true;
            dialog = false;
            Dialog.SetActive(false);
            UI.SetActive(true);
        }

        UI.GetComponent<CanvasGroup>().alpha = mentalBar.GetComponent<Image>().fillAmount;
    }
}
