using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider audioSlider;

    private void Start()
    {
        float saved = PlayerPrefs.GetFloat("Volume", 1f);
        audioSlider.value = saved;

    }

    public void setVolume()
    {
        float volume = audioSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
