using UnityEngine;


public class Enemy : MonoBehaviour
{

    public EnemyScriptableObject enemyStats;
    [SerializeField] float walkingSpeed;
    [SerializeField] EnemyAnimator enemyAnimator;
    [SerializeField] UiManager killcount;
    [SerializeField] Data data;
    int sightrange;
    bool playerFound;
    private int currentHealth;
    bool isVulnerable;




    public LayerMask GroundLayer;
    private void Start()
    {
        isVulnerable = true;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50, GroundLayer))
        {
            transform.position = hit.point;
        }
        currentHealth = enemyStats.health;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!isVulnerable)
        {

            return;
        }
        if (other.gameObject.CompareTag("PlayerSword") || other.gameObject.CompareTag("PlayerDagger"))
        {

            enemyAnimator.EnemyIsDamaged();
            currentHealth -= 5;
            isVulnerable = false;
            Invoke("SetIsVulnerable", 0.5f);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                DataSaver.BestkillCountNum++;
                EnemyLoading.enemyNum--;

            }

        }

    }

    private void SetIsVulnerable() => isVulnerable = true;


}
