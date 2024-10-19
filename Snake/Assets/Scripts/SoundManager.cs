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
            audioSource.volume = newVolume; 
            AudioListener.volume = newVolume;
            PlayerPrefs.SetFloat("Volume", newVolume); 
        }
        else
        {
            Debug.LogError("AudioSource bileþeni atanmadý!");
        }
    }
}
