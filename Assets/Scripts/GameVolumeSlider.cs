using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameVolumeSlider : MonoBehaviour
{
   AudioSource[] audioSources;

    private void Awake()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    public void setVolume(float Volume)
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = Volume;
        }
    }
}
