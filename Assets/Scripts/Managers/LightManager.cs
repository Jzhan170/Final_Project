using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    //private Light[] anxiousLights;
    //Creates an array of light objects which allows specific light objects to be dragged into the inspector
    public Light[] anxiousLights;


    // Start is called before the first frame update
    void Start()
    {
        
       /* anxiousLights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light anxiouslight in anxiousLights)
        {
            anxiouslight.intensity = 0.34f;
            anxiouslight.bounceIntensity = 1.9f;
            anxiouslight.range = 10f;

        } */
        //For loop which runs through the public lights array in order to set their specific settings to specific values at the start of the game.
        for (int i = 0; i < anxiousLights.Length; i ++)
        {
            //Gets the light component properties of the objects in the array
            anxiousLights[i] = anxiousLights[i].GetComponent<Light>();
            anxiousLights[i].intensity = 0.34f;
            anxiousLights[i].bounceIntensity = 1.9f;
            anxiousLights[i].range = 10f;
        }



    }

    public void LightEffects()
    {
       /* foreach (Light anxiouslight in anxiousLights)
        {
            anxiouslight.intensity = Mathf.Lerp(anxiouslight.intensity, 1.20f, .02f * Time.deltaTime);
            anxiouslight.bounceIntensity = Mathf.Lerp(anxiouslight.bounceIntensity, 1f, .02f * Time.deltaTime);
            anxiouslight.range = Mathf.Lerp(anxiouslight.range, 20f, .02f * Time.deltaTime);

        } */
        //For loop which runs through the array and Lerps the values which were set in the Start function to change based on time.
        for (int i = 0; i < anxiousLights.Length; i++)
        {
            anxiousLights[i].intensity = Mathf.Lerp(anxiousLights[i].intensity, 1.20f, .02f * Time.deltaTime);
            anxiousLights[i].bounceIntensity = Mathf.Lerp(anxiousLights[i].bounceIntensity, 1f, .02f * Time.deltaTime);
            anxiousLights[i].range = Mathf.Lerp(anxiousLights[i].range, 20f, .02f * Time.deltaTime);
        }


    }


}
