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
        if (InputManager.Instance.GetPressInput())
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
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pasueMenuUI.SetActive(false);
        sountrackMusic.Play();
    }

    public void Pause()
    {
        pasueMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
