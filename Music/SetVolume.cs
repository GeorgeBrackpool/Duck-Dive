using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    //TODO keep value in slider between scenes using player pref. Check https://johnleonardfrench.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/#playpref 

    private void Start() {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        slider.value = PlayerPrefs.GetFloat("FXVolume", 0.75f);
    }
    public void SetLevel(float SliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (SliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", SliderValue);
    }

    public void SetSoundFXLevel(float SliderValue)
    {
        mixer.SetFloat("SoundFXVol", Mathf.Log10 (SliderValue) * 20);
        PlayerPrefs.SetFloat("FXVolume", SliderValue);
    }
}
