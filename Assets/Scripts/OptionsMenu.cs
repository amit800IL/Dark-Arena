using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
