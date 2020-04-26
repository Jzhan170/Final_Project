using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static bool gameStarted;
    public GameObject Title, UI;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        Title.SetActive(true);
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            Title.SetActive(false);
            UI.SetActive(true);
        }
    }
}
