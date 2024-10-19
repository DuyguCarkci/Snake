using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider; // Slider referansý
    private SoundManager soundManager; // SoundManager referansý

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>(); // SoundManager'ý bul
    }

    private void Start()
    {
        LoadSettings();
        volumeSlider.onValueChanged.AddListener(SetVolume); // Slider deðiþtiðinde ses seviyesini ayarla
    }

    public void LoadSettings()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 1f); // Kaydedilen ses seviyesini yükle
        volumeSlider.value = volume;
        soundManager.SetVolume(volume); // Ses seviyesini ayarla
    }

    public void SetVolume(float newVolume)
    {
        if (soundManager != null)
        {
            soundManager.SetVolume(newVolume); // SoundManager üzerinden ses seviyesini ayarla
        }
        else
        {
            Debug.LogError("SoundManager bileþeni atanmadý!");
        }
    }
}
