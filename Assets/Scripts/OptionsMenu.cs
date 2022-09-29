using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class OptionsMenu : MonoBehaviour
{
    public AudioSource menuAudioSource;
    public void SetVolume(float _volume)
    {
        menuAudioSource.volume = _volume;
    }
}
