using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
    private Vector3 startingPosition;
    public EnemyScriptableObject enemyStats;
    [SerializeField] EnemyAnimator enemyAnimator;
    [SerializeField] Transform enemyPosition;
    [SerializeField] Transform enemyRoation;

    private void Start()
    {
        startingPosition = enemyPosition.position;
    }

    private void Update()
    {
        RunCurrentState();
    }
    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            if (Physics.Raycast(enemyPosition.position, playerPosition.position, out RaycastHit hit))
            {
                enemyAnimator.EnemyChaseState();

                if (Vector3.Distance(enemyPosition.position, playerPosition.position) > 1f)
                {
                    float singleStep = enemyStats.speed * Time.deltaTime;
                    Vector3 newPosition = Vector3.MoveTowards(enemyPosition.position, playerPosition.position, singleStep);
                    transform.LookAt(playerPosition);
                    enemyPosition.position = newPosition;
                    
                }

            }
        }

        return this;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(enemyPosition.position, playerPosition.position);
    }
}
