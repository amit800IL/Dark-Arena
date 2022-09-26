using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoading : MonoBehaviour
{

    [SerializeField] GameObject skeletonDevilRefrence;
    [SerializeField] GameObject skeletonFireRefrence;
    public Transform playerPosition;
    [SerializeField] int maxEnemies;
    [SerializeField] List<EnemyWave> waves;
    [SerializeField] int timeBetweenWaves;
    [SerializeField]Data data;

    int currentEnemies;
    private void Start()
    {
        StartCoroutine(enemyLoader());
    }

    IEnumerator enemyLoader()
    {
        for (int i = 0; waves.Count > i; i++)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            for (int j = 0; j < waves[i].devilAmount; j++)
            {
                
                Instantiate(skeletonDevilRefrence);
                yield return new WaitForEndOfFrame();
                
            }
            yield return new WaitForSeconds(timeBetweenWaves);
            for (int k = 0; k < waves[i].FireAmount; k++)
            {
                Instantiate(skeletonFireRefrence);
                yield return new WaitForEndOfFrame();

            }

            DataSaver.bestWavesSurvivedNum++;
            data.WriteToJson();

           
        }
        
    }
}
[System.Serializable]
class EnemyWave
{
    public int devilAmount;
    public int FireAmount;
}
