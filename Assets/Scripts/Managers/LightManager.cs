using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private Light[] anxiousLights;
    // Start is called before the first frame update
    void Start()
    {
        anxiousLights = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light anxiouslight in anxiousLights)
        {
            anxiouslight.intensity = 0.34f;
            anxiouslight.bounceIntensity = 1.9f;
            anxiouslight.range = 10f;

        }
    }

    public void LightEffects()
    {
        foreach (Light anxiouslight in anxiousLights)
        {
            anxiouslight.intensity = Mathf.Lerp(anxiouslight.intensity, 1.20f, .02f * Time.deltaTime);
            anxiouslight.bounceIntensity = Mathf.Lerp(anxiouslight.bounceIntensity, 1f, .02f * Time.deltaTime);
            anxiouslight.range = Mathf.Lerp(anxiouslight.range, 20f, .02f * Time.deltaTime);

        }
    }


}
