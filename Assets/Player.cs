using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    public Image FoodBar;
    public float startFood = 100;
    public float Food;
    public float HungerPerSec = 1;
    public float foodrecoverAmount = 20;

    public Image SMNBar;
    public float startSMN = 100;
    public float SMN;
    public float SMNLost = 25;
    public float SMNGainRest = 25;
    public float SMNGainEat = 10;

    public Image HealthBar;
    public float startHealth = 100;
    public float Health;
    public float HealthrecoverAmount = 10;
    //public float HealthMinus = 10;
    public float BadHealth = 10;


    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        Food = startFood;
        SMN = startSMN;
        Health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }

        Food -= Time.deltaTime * HungerPerSec;
        FoodBar.fillAmount = Food / startFood;

        //Health -= Time.deltaTime * BadHealthPerSec;
        //HealthBar.fillAmount = Health / startHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            Food += foodrecoverAmount;
            FoodBar.fillAmount = Food / startFood;
            //SMN += SMNGainEat;
            Debug.Log("eating");
            Health -= BadHealth;
            HealthBar.fillAmount = Health / startHealth;
            //add food behavior to the actions
            MentalBarController.ActionOrder += "f";
        }

        if(other.gameObject.tag == "action")
        {
            SMN -= SMNLost;
            SMNBar.fillAmount = SMN / startSMN;

            Health += HealthrecoverAmount;
            HealthBar.fillAmount = Health;
            Debug.Log("acting");
            //add action behavior to the actions
            MentalBarController.ActionOrder += "a";
        }

        if(other.gameObject.tag == "rest")
        {
            SMN += SMNGainRest;
            SMNBar.fillAmount = SMN;
            Debug.Log("sleep");
            //add rest behavior to the actions
            MentalBarController.ActionOrder += "r";
        }
    }
}
