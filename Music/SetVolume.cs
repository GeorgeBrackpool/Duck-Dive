using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    

    private void Start() {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        slider.value = PlayerPrefs.GetFloat("FXVolume", 0.5f);
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
