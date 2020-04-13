using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NewPlayerController : MonoBehaviour
{
    public LayerMask GroundLayer, InteractLayer;

    private NavMeshAgent myAgent;

    public Image FoodBar;
    public static float Food;
    public float HungerPerSec = 1;

    public Image SMNBar;
    public static float SMN;

    public Image HealthBar;
    public static float Health;

    //possible destinations for player to go
    Vector3[] dest;
    GameObject[] interactables;
    //whether the character is in auto route finding mode
    bool auto = true;
    //whether the character is running the route finding coroutine
    bool findingRoute = false;
    bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        dest = new Vector3[interactables.Length];
        for(int i = 0; i < interactables.Length; i++)
        {
            dest[i] = interactables[i].transform.GetChild(0).position;
        }
        myAgent = GetComponent<NavMeshAgent>();
        Food = 100;
        SMN = 100;
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        #region Auto Route Finding
        if (auto && !findingRoute)
        {
            StartCoroutine(FindRoute());
        }
        if (auto && findingRoute && entered)
        {
            StartCoroutine(WaitBeforeMoveAgain());
        }
        #endregion

        #region Manual Route Finding
        if (Input.GetMouseButtonDown(0))
        {
            auto = false;
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, GroundLayer))
            {
                //go to the position of the child (usually the front of the object)
                myAgent.SetDestination(hitInfo.point);
            }
            if (Physics.Raycast(myRay, out hitInfo, 100, InteractLayer))
            {
                //go to the position of the child (usually the front of the object)
                myAgent.SetDestination(hitInfo.transform.GetChild(0).position);
            }
        }
        #endregion

        Food -= Time.deltaTime * HungerPerSec;
        FoodBar.fillAmount = Food / 100;

        //clamp the floats between 0 and 100
        Food = Mathf.Clamp(Food, 0, 100);
        SMN = Mathf.Clamp(SMN, 0, 100);
        Health = Mathf.Clamp(Health, 0, 100);
    }
    IEnumerator FindRoute()
    {
        //Debug.Log("findroute");
        findingRoute = true;
        entered = false;
        yield return new WaitForSeconds(Random.Range(2, 4));
        int r = Random.Range(0, dest.Length);
        myAgent.SetDestination(dest[r]);
    }

    IEnumerator WaitBeforeMoveAgain()
    {
        Debug.Log("waiting");
        entered = false;
        yield return new WaitForSeconds(Random.Range(2, 4));
        findingRoute = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
        auto = true;
        for(int i = 0; i < interactables.Length; i++)
        {
            if (other.gameObject == interactables[i])
            {
                MentalBarController.ActionOrder += i;
                Debug.Log(MentalBarController.ActionOrder);
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.GetChild(0).position == myAgent.destination)
        {
            entered = true;
            Debug.Log("same destination");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        entered = false;
    }
}
