using UnityEngine;


public class Enemy : MonoBehaviour
{

    int sightrange;
    [SerializeField] float walkingSpeed;
    bool playerFound;
    [SerializeField] EnemyAnimator enemyAnimator;
    public EnemyScriptableObject enemyStats;
    private int currentHealth;
    UiManager killcount;
    [SerializeField] Data data;
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
            }
            data.WriteToJson();
        }
       
    }

    private void SetIsVulnerable() => isVulnerable = true;


}
