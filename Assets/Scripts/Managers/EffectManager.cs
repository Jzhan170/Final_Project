using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectManager : MonoBehaviour
{
    public PostProcessVolume distortion;

    private LensDistortion lensDistortion;
    private ChromaticAberration chromAberration;
    private Grain grain;
    // Start is called before the first frame update
    void Start()
    {
        distortion.profile.TryGetSettings(out lensDistortion);
        lensDistortion.intensity.value = 0;
        lensDistortion.scale.value = 1;
        distortion.profile.TryGetSettings(out chromAberration);
        chromAberration.intensity.value = 0;
        distortion.profile.TryGetSettings(out grain);
        grain.intensity.value = 0;
        grain.size.value = 0;
    }


    public void DistortionEffects()
    {
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, 90, .05f * Time.deltaTime);
        grain.intensity.value = Mathf.Lerp(grain.intensity.value, 0.5f, .05f * Time.deltaTime);
        grain.size.value = Mathf.Lerp(grain.size.value, 2.5f, .05f * Time.deltaTime);
        lensDistortion.scale.value = Mathf.Lerp(lensDistortion.scale.value, .8f, .05f * Time.deltaTime);
        chromAberration.intensity.value = Mathf.Lerp(chromAberration.intensity.value, 1, .05f * Time.deltaTime);
    }
}
