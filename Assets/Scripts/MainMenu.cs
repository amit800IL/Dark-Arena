using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    bool isClicked;
    private void Start()
    {
        //InputManager.Instance.useGUILayout = true;
        //InputManager.Instance.onClick.AddListener(PlayGame);
        //InputManager.Instance.onClick.AddListener(QuitGame);

    }
    public void PlayGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
