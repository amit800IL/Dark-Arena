using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange => Vector3.Distance(fatherTransform.position, playerPosition.position) < RangeToAttack;
    public EnemyScriptableObject enemyStats;
    [SerializeField] EnemyAnimator enemyAnimator;
    [SerializeField] Transform fatherTransform;
    [SerializeField] float RangeToAttack;
    [SerializeField] NavMeshAgent m_agent;
    
    public override State RunCurrentState()
    {
       
        if (isInAttackRange)
        {
            m_agent.SetDestination(fatherTransform.position);
            return attackState;

        }

        enemyAnimator.EnemyChaseState();
        m_agent.SetDestination(playerPosition.position);


        return this;


    }

   
}
