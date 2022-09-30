using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreens : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject LossScreen;
    EnemyLoading enemyLoading;

    private void Update()
    {
        
        Defeat();

    }
    public void Defeat()
    {
        if (PlayerStats.Instance.health <= 0)
        {
            Time.timeScale = 0f;
            LossScreen.SetActive(true);

        }

        else
        {
            Time.timeScale = 1f;
        }


    }

    void victory()
    {
        Time.timeScale = 0f;
        VictoryScreen.SetActive(true);

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quitgame()
    {
      Application.Quit();
    }
}


