using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float newVolume)
    {
        if (audioSource != null)
        {
            audioSource.volume = newVolume; // Ses seviyesini ayarla
            AudioListener.volume = newVolume; // Genel ses seviyesini ayarla
            PlayerPrefs.SetFloat("Volume", newVolume); // Ses seviyesini kaydet
        }
        else
        {
            Debug.LogError("AudioSource bileþeni atanmadý!");
        }
    }
}
