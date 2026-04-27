using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    public Volume volume;
    public Slider brightnessSlider;

    private ColorAdjustments colorAdjustments;

    void Start()
    {
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float saved = PlayerPrefs.GetFloat("Brightness", 0f);
            brightnessSlider.value = saved;
            SetBrightness(saved);
        }

        brightnessSlider.onValueChanged.AddListener(SetBrightness);
    }

    public void SetBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
            PlayerPrefs.SetFloat("Brightness", value);
        }
    }
}