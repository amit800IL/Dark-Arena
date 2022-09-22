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


    public LayerMask GroundLayer;
    private void Start()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50, GroundLayer))
        {
            transform.position = hit.point;
        }
        currentHealth = enemyStats.health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerSword") || other.gameObject.CompareTag("PlayerDagger"))
        {
            Destroy(gameObject);
            DataSaver.BestkillCountNum++;
        }
    }

}
