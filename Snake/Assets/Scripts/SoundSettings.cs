using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider; // Slider referans�
    private SoundManager soundManager; // SoundManager referans�

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>(); // SoundManager'� bul
    }

    private void Start()
    {
        LoadSettings();
        volumeSlider.onValueChanged.AddListener(SetVolume); // Slider de�i�ti�inde ses seviyesini ayarla
    }

    public void LoadSettings()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f); // Kaydedilen ses seviyesini y�kle
        volumeSlider.value = volume;
        soundManager.SetVolume(volume); // Ses seviyesini ayarla
    }

    public void SetVolume(float newVolume)
    {
        if (soundManager != null)
        {
            soundManager.SetVolume(newVolume); // SoundManager �zerinden ses seviyesini ayarla
        }
        else
        {
            Debug.LogError("SoundManager bile�eni atanmad�!");
        }
    }
}
