using UnityEngine;


public class Enemy : MonoBehaviour
{

    int sightrange;
    [SerializeField] float walkingSpeed;
    bool playerFound;
    EnemyAnimator enemyAnimator;
    public EnemyScriptableObject enemyStats;
    public int currentHealth;
    KillCount killcount;



    private void Start()
    {
        currentHealth = enemyStats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerSword") || other.gameObject.CompareTag("PlayerDagger"))
        {
            Destroy(gameObject);
            killcount.counting();
            killcount.killcountNum++;
        }
    }

}
