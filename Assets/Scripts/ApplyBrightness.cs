using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ApplyBrightness : MonoBehaviour
{
    public Volume volume;
    private ColorAdjustments colorAdjustments;

    void Start()
    {
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float saved = PlayerPrefs.GetFloat("Brightness", 0f);
            colorAdjustments.postExposure.value = saved;
        }
    }
}