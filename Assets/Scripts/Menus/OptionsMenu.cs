using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class OptionsMenu : MonoBehaviour
{
    public AudioSource menuAudioSource;
    [SerializeField]private Data data;

   
    public void SetVolume(float _volume)
    {
        menuAudioSource.volume = _volume;
    }

    public void RestoreData()
    {
       //data.RestoreJson();
    }
}
