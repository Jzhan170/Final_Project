using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentalBarController : MonoBehaviour
{
    //stores player's actions; new character is added in the Player script
    public static string ActionOrder;
    //detecting whether the mental bar is below a certain amount
    public static bool belowHalf, belowQuater, isZero;

    public Image mentalBar;
    public float reduceAmount;
    public float hungryTime, staminaTime, healthTime;

    [SerializeField]
    int oldLength, newLength;
    float hungryTimer = 0;
    float staminaTimer = 0;
    float healthTimer = 0;

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

        //clamp the mental bar fillAmount between 0 and 1
        mentalBar.fillAmount = Mathf.Clamp(mentalBar.fillAmount, 0, 1);
        
        //set decters to true
        if (mentalBar.fillAmount <= .5f)
        {
            belowHalf = true;
        }
        else
        {
            belowHalf = false;
        }
        if (mentalBar.fillAmount <= .25f)
        {
            belowQuater = true;
        }
        else
        {
            belowQuater = false;
        }
        if (mentalBar.fillAmount == 0)
        {
            isZero = true;
        }
        else
        {
            isZero = false;
        }

        //if new behaviors are done and the player has done over four behaviors, detect if the behaviors are done repeatitively. if so, reduce mental bar
        if (newLength > oldLength && newLength >= 4)
        {
            //if player do one thing repeatitively (e.g. eat eat eat)
            if (ActionOrder[newLength-1] == ActionOrder[newLength - 2])
            {
                mentalBar.fillAmount -= reduceAmount / 100;
                oldLength = newLength;
            }
            //if player do two things repeatitively (e.g. eat sleep eat sleep)
            if (ActionOrder[newLength - 1] == ActionOrder[newLength - 3] && ActionOrder[newLength - 2] == ActionOrder[newLength - 4])
            {
                mentalBar.fillAmount -= reduceAmount / 100;
                oldLength = newLength;
            }
        }

        //if food bar is empty for a while
        if (Player.Food <= 0)
        {
            hungryTimer += Time.deltaTime;
            if (hungryTimer >= hungryTime)
            {
                mentalBar.fillAmount -= 0.0001f;
            }
        }
        //if stamina bar drops under 1/3 for a while
        if (Player.SMN <= 33)
        {
            
            staminaTimer += Time.deltaTime;
            if (staminaTimer >= staminaTime)
            {
                mentalBar.fillAmount -= 0.0001f;
            }
        }
        //if health bar drops under 1/2 for a while
        if (Player.Health <= 50)
        {
            healthTimer += Time.deltaTime;
            if (healthTimer >= healthTime)
            {
                mentalBar.fillAmount -= 0.0001f;
            }
        }
    }
}
