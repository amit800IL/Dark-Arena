using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI PlayerKillCount;
    [SerializeField] TextMeshProUGUI PlayerBestWavesCount;

    private void Update()
    {
        counting();
    }
    public void counting()
    {
     
        PlayerKillCount.text = "Best Kill Count: " + DataSaver.BestkillCountNum.ToString();
        PlayerBestWavesCount.text = "Best Waves Count : " + DataSaver.bestWavesSurvivedNum.ToString();
        
    }
}
