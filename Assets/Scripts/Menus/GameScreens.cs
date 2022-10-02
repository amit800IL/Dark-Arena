using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreens : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject LossScreen;

    private void Update()
    {

        Victory();
        Defeat();

    }
    public void Defeat()
    {

        if (PlayerStats.Instance.health <= 0)
        {

          
            LossScreen.SetActive(true);
            Time.timeScale = 0f;

        }

        else
        {

            LossScreen.SetActive(false);
            Time.timeScale = 1f;
        }


    }

    public void Victory()
    {

        if (EnemyLoading.enemyNum <= 0)
        {

            VictoryScreen.SetActive(true);
            Time.timeScale = 0f;

        }

        else
        {

            Time.timeScale = 1f;
            VictoryScreen.SetActive(false);

        }


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


