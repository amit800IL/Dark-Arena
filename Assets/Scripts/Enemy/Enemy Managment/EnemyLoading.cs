using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLoading : MonoBehaviour
{
   
    public Transform playerPosition;
    public List<EnemyWave> EasyWaves;
    public List<EnemyWave> MediumWaves;
    public List<EnemyWave> HardWaves;
    private int currentEnemies;
    [SerializeField] GameObject skeletonDevilRefrence;
    [SerializeField] GameObject skeletonFireRefrence;
    [SerializeField] int maxEnemies;
    [SerializeField] int timeBetweenWaves;
    [SerializeField] Data data;
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameScreens screens;

    private void Start()
    {
       
        List<EnemyWave> currentEnemyWaves = GetCurrentWave();
        StartCoroutine(enemyLoader(currentEnemyWaves));
    }

    private List<EnemyWave> GetCurrentWave()
    {
        int Diff = PlayerPrefs.GetInt("Diff");

        switch (Diff)
        {
            case 0:
                return EasyWaves;
            case 1:
                return MediumWaves;
            case 2:
                return HardWaves;

            default: return EasyWaves;

        }
    }
    IEnumerator enemyLoader(List<EnemyWave> enemyWaves)
    {
        for (int i = 0; enemyWaves.Count > i; i++)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            for (int j = 0; j < enemyWaves[i].devilAmount; j++)
            {

                GameObject temp = Instantiate(skeletonDevilRefrence);
                temp.GetComponent<AudioSource>().volume = volumeSlider.value;
                yield return new WaitForEndOfFrame();

            }
            yield return new WaitForSeconds(timeBetweenWaves);
            for (int k = 0; k < enemyWaves[i].FireAmount; k++)
            {
                GameObject temp = Instantiate(skeletonFireRefrence);
                temp.GetComponent<AudioSource>().volume = volumeSlider.value;
                yield return new WaitForEndOfFrame();

            }

            DataSaver.bestWavesSurvivedNum++;
            data.WriteToJson();



        }

    }
}
[System.Serializable]
public class EnemyWave
{
    public int devilAmount;
    public int FireAmount;
}
