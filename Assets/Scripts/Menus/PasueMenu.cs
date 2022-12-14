using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PasueMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pasueMenuUI;
    public AudioSource sountrackMusic;
  

    private void Start()
    {
        InputManager.Instance.onClick.AddListener(PasueInput);

    }


    public void PasueInput()
    {

        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pasueMenuUI.SetActive(false);
        sountrackMusic.Play();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pasueMenuUI.SetActive(true);
        gameIsPaused = true;
        sountrackMusic.Pause();
       
    }

    public void loadeMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        
    }

    public void quieGame()
    {
        Application.Quit();
    }
}
