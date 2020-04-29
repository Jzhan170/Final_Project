using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    
    //Creates an array of light objects which allows specific light objects to be dragged into the inspector
    public Light[] anxiousLights;
    public Light lampLight;


    // Start is called before the first frame update
    void Start()
    {
        
    
        //For loop which runs through the public lights array in order to set their specific settings to specific values at the start of the game.
        for (int i = 0; i < anxiousLights.Length; i ++)
        {
            //Gets the light component properties of the objects in the array
            anxiousLights[i] = anxiousLights[i].GetComponent<Light>();
            anxiousLights[i].intensity = 0.34f;
            anxiousLights[i].bounceIntensity = 1.9f;
            anxiousLights[i].range = 10f;
        }

        lampLight.intensity = 0f;
        lampLight.bounceIntensity = 0f;
        lampLight.range = 0f;
        lampLight.shadowStrength = 0f;

        InvokeRepeating("LampLight", 0, 44f);

    }

    public void LightEffects()
    {
  
        //For loop which runs through the array and Lerps the values which were set in the Start function to change based on time.
        for (int i = 0; i < anxiousLights.Length; i++)
        {
            anxiousLights[i].intensity = Mathf.Lerp(anxiousLights[i].intensity, 1.20f, .04f * Time.deltaTime);
            anxiousLights[i].bounceIntensity = Mathf.Lerp(anxiousLights[i].bounceIntensity, 1f, .04f * Time.deltaTime);
            anxiousLights[i].range = Mathf.Lerp(anxiousLights[i].range, 20f, .04f * Time.deltaTime);
        }


    }

    public void LampLight()
    {
        lampLight.intensity = Mathf.Lerp(lampLight.intensity, 1.42f, .04f * Time.deltaTime);
        lampLight.bounceIntensity = Mathf.Lerp(lampLight.bounceIntensity, 1.9f, .04f * Time.deltaTime);
        lampLight.range = Mathf.Lerp(lampLight.range, 7.81f, .04f * Time.deltaTime);
        lampLight.shadowStrength = Mathf.Lerp(lampLight.shadowStrength, .659f, .04f * Time.deltaTime);
    }


}
