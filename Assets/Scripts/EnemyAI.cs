using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPosition;
    public EnemyScriptableObject enemyStats;
    [SerializeField] Transform playerPosition;
    [SerializeField] EnemyAnimator enemyAnimator;



    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {

        if (Physics.Raycast(transform.position, playerPosition.position, out RaycastHit hit))
        {
            if (Vector3.Distance(transform.position, playerPosition.position) > 1.5f)
            {
                float singleStep = enemyStats.speed * Time.deltaTime;
                Vector3 newPosition = Vector3.MoveTowards(transform.position, playerPosition.position, singleStep);
                transform.position = newPosition;

              
                
            }
            else
            {

                enemyAnimator.triggerAttack();
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, playerPosition.position);
    }

}
