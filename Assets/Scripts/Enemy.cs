using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform enemyPosition;
    int sightrange;
    [SerializeField] float walkingSpeed;
    bool playerFound;
    EnemyAnimator enemyAnimator;
    public EnemyScriptableObject enemyStats;
    public int currentHealth;
    public CombatManager enemyCombat;

    private void Start()
    {
        currentHealth = enemyStats.health;
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
   
        if (Physics.Raycast(transform.position, playerPosition.position, out RaycastHit hit))
        {
            if(Vector3.Distance(transform.position, playerPosition.position) > 1.5f)
            {
                float singleStep = enemyStats.speed * Time.deltaTime;
                Vector3 newPosition = Vector3.MoveTowards(transform.position, playerPosition.position, singleStep);
                transform.position = newPosition;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(enemyPosition.position, playerPosition.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerSword") || collision.gameObject.CompareTag("PlayerDagger"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerSword") || other.gameObject.CompareTag("PlayerDagger"))
        {
            Destroy(gameObject);
        }
    }

}
