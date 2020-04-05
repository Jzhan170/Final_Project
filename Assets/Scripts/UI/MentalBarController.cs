using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalBarController : MonoBehaviour
{
    //stores player's actions; new character is added in the Player script
    public static string ActionOrder;

    public Image mentalBar;
    public float reduceAmount;

    [SerializeField]
    int oldLength, newLength;

    

    // Start is called before the first frame update
    void Start()
    {
        ActionOrder = "";
        oldLength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        newLength = ActionOrder.Length;
        //if new behaviors are done and the player has done over four behaviors, detect if the behaviors are done repeatitively. if so, reduce mental bar
        if (newLength > oldLength && newLength >= 4)
        {
            for(int i = newLength-1; i > newLength-4; i--)
            {
                //if player do one thing repeatitively (e.g. eat eat eat)
                if (ActionOrder[i] == ActionOrder[i - 1])
                {
                    mentalBar.fillAmount -= reduceAmount / 100;
                    oldLength = newLength;
                }
            }
            //if player do two things repeatitively (e.g. eat sleep eat sleep)
            if (ActionOrder[newLength - 1] == ActionOrder[newLength - 3] && ActionOrder[newLength - 2] == ActionOrder[newLength - 4])
            {
                mentalBar.fillAmount -= reduceAmount / 100;
                oldLength = newLength;
            }
        }
    }
}
