using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{
    public int killcountNum;
    [SerializeField] TextMeshProUGUI PlayerKillCount;

    private void Update()
    {
        counting();
    }
    public void counting()
    {
        PlayerKillCount.text = "Best Kill Count: " + killcountNum.ToString();
        
    }
}
