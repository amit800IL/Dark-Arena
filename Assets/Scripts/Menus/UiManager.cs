using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI PlayerKillCount;
    [SerializeField] TextMeshProUGUI PlayerBestWavesCount;
    [SerializeField] TextMeshProUGUI playerHealth;

    private void Update()
    {
        PlayerUi();
    }
    public void PlayerUi()
    {
     
        PlayerKillCount.text = "Best Kill Count: " + DataSaver.BestkillCountNum.ToString();
        PlayerBestWavesCount.text = "Best Waves Count : " + DataSaver.bestWavesSurvivedNum.ToString();
        playerHealth.text = "Player Health" + PlayerStats.Instance.health.ToString();
        
    }
}
