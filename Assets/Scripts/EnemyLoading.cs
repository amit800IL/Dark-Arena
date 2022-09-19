using System.Collections;
using UnityEngine;

public class EnemyLoading : MonoBehaviour
{

    [SerializeField] GameObject skeletonDevilRefrence;
    [SerializeField] GameObject skeletonFireRefrence;
    public Transform playerPosition;
    [SerializeField] int maxEnemies;

    int currentEnemies;
    private void Start()
    {
        StartCoroutine(enemyLoader());
    }

    IEnumerator enemyLoader()
    {
        while (currentEnemies < maxEnemies)
        {
            yield return new WaitForSeconds(1);
            GameObject summonedEnemyGO = Instantiate(skeletonDevilRefrence);
            StateManager summonedEnemy = summonedEnemyGO.GetComponent<StateManager>();
            summonedEnemy.attackRef.playerPosition = playerPosition;
            summonedEnemy.chaseRef.playerPosition = playerPosition;

            yield return new WaitForSeconds(1);
            GameObject summonedEnemyGO2 = Instantiate(skeletonFireRefrence);
            StateManager summonedEnemy2 = summonedEnemyGO2.GetComponent<StateManager>();
            summonedEnemy2.attackRef.playerPosition = playerPosition;
            summonedEnemy2.chaseRef.playerPosition = playerPosition;

            currentEnemies += 2;
        }
    }
}
