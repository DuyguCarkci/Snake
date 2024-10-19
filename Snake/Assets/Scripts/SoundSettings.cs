using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;
    private SoundManager soundManager; 

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        LoadSettings();
        volumeSlider.onValueChanged.AddListener(SetVolume); 
    }

    public void LoadSettings()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f); 
        volumeSlider.value = volume;
        soundManager.SetVolume(volume);
    }

    public void SetVolume(float newVolume)
    {
        if (soundManager != null)
        {
            soundManager.SetVolume(newVolume); 
        }
        else
        {
            Debug.LogError("SoundManager bileþeni atanmadý!");
        }
    }
}
